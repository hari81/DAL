namespace DAL.UCMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifySP_store_contact_4T : DbMigration
    {
        public override void Up()
        {
            Sql(store_contact_4T);
        }
        
        public override void Down()
        {
            Sql(store_contact_4T_down);
        }
        string store_contact_4T = @"
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


--modified by Rumesh MM on 07-07-2008 updated to work with new Contact By user and contact by cistomer page
--modified by JJW 08/05/07 to add 'jobsite' attribute 

ALTER PROCEDURE [dbo].[store_contact_4T]
	@customer_auto	bigint = null,
	@user_auto		bigint = 0,
	@crsf_auto		bigint = 0,
	@equip_auto		bigint = 0,
	@str_user_autos varchar(500) = '',
	@str_crsf_autos varchar(500) = '',
	@str_equip_autos varchar(500) = '',
	@mode varchar(500) = '',
	@user_assigned bit = 0,
	@modified_user  bigint = null,
	@ret_value	int output
   
AS
DECLARE @EvalA	bit, @EvalB	bit, @EvalC	bit, @EvalX	bit
	
SELECT @EvalA = EvalA,@EvalB=EvalB,@EvalC=EvalC,@EvalX=EvalX FROM USER_TABLE WHERE user_auto = @user_auto

IF @EvalA IS NULL 
SET @EvalA = 1

IF @EvalB IS NULL 
SET @EvalB = 1

IF @EvalC IS NULL 
SET @EvalC = 1

IF @EvalX IS NULL 
SET @EvalX = 1

IF @mode = 'jobsite'
BEGIN
BEGIN TRANSACTION t1
	DECLARE contact_cursor CURSOR READ_ONLY FAST_FORWARD
	FOR
		SELECT value FROM dbo.fn_split(@str_crsf_autos, '~')

	DECLARE @crsfauto as bigint

	OPEN contact_cursor
	FETCH NEXT FROM contact_cursor INTO @crsfauto
	WHILE @@FETCH_STATUS = 0
		BEGIN
		
		INSERT INTO CONTACTS (equipmentid_auto,customer_auto,user_auto,EvalA,EvalB,EvalC,EvalX,Type, crsf_auto, modified_user, modified_date)
	    VALUES( 0, @customer_auto, @user_auto, @EvalA, @EvalB, @EvalC, @EvalX, 'SITE', @crsfauto, @modified_user, getdate())	
	
		IF @@ERROR <> 0 
		goto err

		IF @user_assigned = 1
			INSERT INTO USER_CRSF_CUST_EQUIP (user_auto, customer_auto, crsf_auto, equipmentid_auto, level_type, keep_with_equip, modified_user_auto, modified_date)
			VALUES (@user_auto, @customer_auto, @crsfauto, null, 2, 0, @modified_user, getdate())
		
		IF @@ERROR <> 0 
		goto err

		FETCH NEXT FROM contact_cursor INTO @crsfauto
		END
	CLOSE contact_cursor
	DEALLOCATE contact_cursor	
COMMIT TRANSACTION t1
END
ELSE IF @mode = 'customer'
BEGIN
	
BEGIN TRANSACTION t1
	INSERT INTO CONTACTS (equipmentid_auto,customer_auto,user_auto,EvalA,EvalB,EvalC,EvalX,Type, crsf_auto, modified_user, modified_date,eq_undercarriage)
    VALUES( 0, @customer_auto, @user_auto, @EvalA, @EvalB, @EvalC, @EvalX, 'CUST', 0, @modified_user, getdate(),1)	

	IF @@ERROR <> 0 
	goto err

	IF @user_assigned = 1
		INSERT INTO USER_CRSF_CUST_EQUIP (user_auto, customer_auto, crsf_auto, equipmentid_auto, level_type, keep_with_equip, modified_user_auto, modified_date)
		VALUES (@user_auto, @customer_auto, null, null, 1, 0, @modified_user, getdate())
	
	IF @@ERROR <> 0 
	goto err

COMMIT TRANSACTION t1
END
ELSE IF @mode = 'equipment'
BEGIN
BEGIN TRANSACTION t1
DECLARE contact_cursor CURSOR READ_ONLY FAST_FORWARD
	FOR
		SELECT value FROM dbo.fn_split(@str_equip_autos, '~')

	DECLARE @eq_auto as bigint

	OPEN contact_cursor
	FETCH NEXT FROM contact_cursor INTO @eq_auto
	WHILE @@FETCH_STATUS = 0
		BEGIN
		
		INSERT INTO CONTACTS (equipmentid_auto,customer_auto,user_auto,EvalA,EvalB,EvalC,EvalX,Type, crsf_auto, modified_user, modified_date)
	    VALUES( @eq_auto, @customer_auto, @user_auto, @EvalA, @EvalB, @EvalC, @EvalX, 'EQ', CAST(@str_crsf_autos as bigint), @modified_user, getdate())	
	
		IF @@ERROR <> 0 
		goto err

		IF @user_assigned = 1
			INSERT INTO USER_CRSF_CUST_EQUIP (user_auto, customer_auto, crsf_auto, equipmentid_auto, level_type, keep_with_equip, modified_user_auto, modified_date)
			VALUES (@user_auto, @customer_auto, CAST(@str_crsf_autos as bigint), @eq_auto, 3, 0, @modified_user, getdate())
		
		IF @@ERROR <> 0 
		goto err

		FETCH NEXT FROM contact_cursor INTO @eq_auto
		END
	CLOSE contact_cursor
	DEALLOCATE contact_cursor	
COMMIT TRANSACTION t1
END
ELSE IF @mode = 'jobsitecust' OR @mode = 'equipmentcust'
BEGIN
BEGIN TRANSACTION t1
	DECLARE contact_cursor CURSOR READ_ONLY FAST_FORWARD
	FOR
		SELECT value FROM dbo.fn_split(@str_user_autos, '~')

	DECLARE @userauto as bigint

	OPEN contact_cursor
	FETCH NEXT FROM contact_cursor INTO @userauto
	WHILE @@FETCH_STATUS = 0
		BEGIN
		SELECT @EvalA = EvalA,@EvalB=EvalB,@EvalC=EvalC,@EvalX=EvalX FROM USER_TABLE WHERE user_auto = @userauto

		IF @mode = 'jobsitecust'
			INSERT INTO CONTACTS (equipmentid_auto,customer_auto,user_auto,EvalA,EvalB,EvalC,EvalX,Type, crsf_auto, modified_user, modified_date)
			VALUES( 0, @customer_auto, @userauto, @EvalA, @EvalB, @EvalC, @EvalX, 'SITE', @crsf_auto, @modified_user, getdate())	
		ELSE
			INSERT INTO CONTACTS (equipmentid_auto,customer_auto,user_auto,EvalA,EvalB,EvalC,EvalX,Type, crsf_auto, modified_user, modified_date)
			VALUES( @equip_auto, @customer_auto, @userauto, @EvalA, @EvalB, @EvalC, @EvalX, 'EQ', @crsf_auto, @modified_user, getdate())	
		
		IF @@ERROR <> 0 
		goto err

		FETCH NEXT FROM contact_cursor INTO @userauto
		END
	CLOSE contact_cursor
	DEALLOCATE contact_cursor	
COMMIT TRANSACTION t1
END

SET @ret_Value = 1
return

err:
SET @ret_Value = 0
CLOSE contact_cursor
DEALLOCATE contact_cursor
ROLLBACK TRANSACTION t1
return

";


        string store_contact_4T_down = @"
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


--modified by Rumesh MM on 07-07-2008 updated to work with new Contact By user and contact by cistomer page
--modified by JJW 08/05/07 to add 'jobsite' attribute 

ALTER PROCEDURE [dbo].[store_contact_4T]
	@customer_auto	bigint = null,
	@user_auto		bigint = 0,
	@crsf_auto		bigint = 0,
	@equip_auto		bigint = 0,
	@str_user_autos varchar(500) = '',
	@str_crsf_autos varchar(500) = '',
	@str_equip_autos varchar(500) = '',
	@mode varchar(500) = '',
	@user_assigned bit = 0,
	@modified_user  bigint = null,
	@ret_value	int output
   
AS
DECLARE @EvalA	bit, @EvalB	bit, @EvalC	bit, @EvalX	bit
	
SELECT @EvalA = EvalA,@EvalB=EvalB,@EvalC=EvalC,@EvalX=EvalX FROM USER_TABLE WHERE user_auto = @user_auto

IF @mode = 'jobsite'
BEGIN
BEGIN TRANSACTION t1
	DECLARE contact_cursor CURSOR READ_ONLY FAST_FORWARD
	FOR
		SELECT value FROM dbo.fn_split(@str_crsf_autos, '~')

	DECLARE @crsfauto as bigint

	OPEN contact_cursor
	FETCH NEXT FROM contact_cursor INTO @crsfauto
	WHILE @@FETCH_STATUS = 0
		BEGIN
		
		INSERT INTO CONTACTS (equipmentid_auto,customer_auto,user_auto,EvalA,EvalB,EvalC,EvalX,Type, crsf_auto, modified_user, modified_date)
	    VALUES( 0, @customer_auto, @user_auto, @EvalA, @EvalB, @EvalC, @EvalX, 'SITE', @crsfauto, @modified_user, getdate())	
	
		IF @@ERROR <> 0 
		goto err

		IF @user_assigned = 1
			INSERT INTO USER_CRSF_CUST_EQUIP (user_auto, customer_auto, crsf_auto, equipmentid_auto, level_type, keep_with_equip, modified_user_auto, modified_date)
			VALUES (@user_auto, @customer_auto, @crsfauto, null, 2, 0, @modified_user, getdate())
		
		IF @@ERROR <> 0 
		goto err

		FETCH NEXT FROM contact_cursor INTO @crsfauto
		END
	CLOSE contact_cursor
	DEALLOCATE contact_cursor	
COMMIT TRANSACTION t1
END
ELSE IF @mode = 'customer'
BEGIN
	
BEGIN TRANSACTION t1
	INSERT INTO CONTACTS (equipmentid_auto,customer_auto,user_auto,EvalA,EvalB,EvalC,EvalX,Type, crsf_auto, modified_user, modified_date,eq_undercarriage)
    VALUES( 0, @customer_auto, @user_auto, @EvalA, @EvalB, @EvalC, @EvalX, 'CUST', 0, @modified_user, getdate(),1)	

	IF @@ERROR <> 0 
	goto err

	IF @user_assigned = 1
		INSERT INTO USER_CRSF_CUST_EQUIP (user_auto, customer_auto, crsf_auto, equipmentid_auto, level_type, keep_with_equip, modified_user_auto, modified_date)
		VALUES (@user_auto, @customer_auto, null, null, 1, 0, @modified_user, getdate())
	
	IF @@ERROR <> 0 
	goto err

COMMIT TRANSACTION t1
END
ELSE IF @mode = 'equipment'
BEGIN
BEGIN TRANSACTION t1
DECLARE contact_cursor CURSOR READ_ONLY FAST_FORWARD
	FOR
		SELECT value FROM dbo.fn_split(@str_equip_autos, '~')

	DECLARE @eq_auto as bigint

	OPEN contact_cursor
	FETCH NEXT FROM contact_cursor INTO @eq_auto
	WHILE @@FETCH_STATUS = 0
		BEGIN
		
		INSERT INTO CONTACTS (equipmentid_auto,customer_auto,user_auto,EvalA,EvalB,EvalC,EvalX,Type, crsf_auto, modified_user, modified_date)
	    VALUES( @eq_auto, @customer_auto, @user_auto, @EvalA, @EvalB, @EvalC, @EvalX, 'EQ', CAST(@str_crsf_autos as bigint), @modified_user, getdate())	
	
		IF @@ERROR <> 0 
		goto err

		IF @user_assigned = 1
			INSERT INTO USER_CRSF_CUST_EQUIP (user_auto, customer_auto, crsf_auto, equipmentid_auto, level_type, keep_with_equip, modified_user_auto, modified_date)
			VALUES (@user_auto, @customer_auto, CAST(@str_crsf_autos as bigint), @eq_auto, 3, 0, @modified_user, getdate())
		
		IF @@ERROR <> 0 
		goto err

		FETCH NEXT FROM contact_cursor INTO @eq_auto
		END
	CLOSE contact_cursor
	DEALLOCATE contact_cursor	
COMMIT TRANSACTION t1
END
ELSE IF @mode = 'jobsitecust' OR @mode = 'equipmentcust'
BEGIN
BEGIN TRANSACTION t1
	DECLARE contact_cursor CURSOR READ_ONLY FAST_FORWARD
	FOR
		SELECT value FROM dbo.fn_split(@str_user_autos, '~')

	DECLARE @userauto as bigint

	OPEN contact_cursor
	FETCH NEXT FROM contact_cursor INTO @userauto
	WHILE @@FETCH_STATUS = 0
		BEGIN
		SELECT @EvalA = EvalA,@EvalB=EvalB,@EvalC=EvalC,@EvalX=EvalX FROM USER_TABLE WHERE user_auto = @userauto

		IF @mode = 'jobsitecust'
			INSERT INTO CONTACTS (equipmentid_auto,customer_auto,user_auto,EvalA,EvalB,EvalC,EvalX,Type, crsf_auto, modified_user, modified_date)
			VALUES( 0, @customer_auto, @userauto, @EvalA, @EvalB, @EvalC, @EvalX, 'SITE', @crsf_auto, @modified_user, getdate())	
		ELSE
			INSERT INTO CONTACTS (equipmentid_auto,customer_auto,user_auto,EvalA,EvalB,EvalC,EvalX,Type, crsf_auto, modified_user, modified_date)
			VALUES( @equip_auto, @customer_auto, @userauto, @EvalA, @EvalB, @EvalC, @EvalX, 'EQ', @crsf_auto, @modified_user, getdate())	
		
		IF @@ERROR <> 0 
		goto err

		FETCH NEXT FROM contact_cursor INTO @userauto
		END
	CLOSE contact_cursor
	DEALLOCATE contact_cursor	
COMMIT TRANSACTION t1
END

SET @ret_Value = 1
return

err:
SET @ret_Value = 0
CLOSE contact_cursor
DEALLOCATE contact_cursor
ROLLBACK TRANSACTION t1
return
";
    }
}
