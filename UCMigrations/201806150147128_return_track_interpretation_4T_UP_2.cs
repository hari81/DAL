namespace DAL.UCMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class return_track_interpretation_4T_UP_2 : DbMigration
    {
        public override void Up()
        {
            Sql(@"
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[return_track_interpretation_4T]
	@customer_auto	bigint,
	@crsf_auto		bigint,
	@serialno		varchar(50),
	@status			int, -- 0 all; 1 Interpretated; 2 not Interpretated
	@make_auto		int,
	@type_auto		int,
	@model_auto		int,
	@start_date		DateTime,
	@end_date		DateTime,
	@incl_evalA		bit,
	@incl_evalB		bit,
	@incl_evalC		bit,
	@incl_evalX		bit,
	@page_no		int,
	@rec_per_page	int,
	@user_auto		bigint
as
declare @need_rec int
set @need_rec = @page_no * @rec_per_page	
if dbo.fn_return_internal_emp_status(@user_auto) = 0
begin
	select count(distinct ti.inspection_auto)as record_no, @rec_per_page as rec_per_page
	from 
		EQUIPMENT eq
		inner join LU_MMTA mmta on eq.mmtaid_auto = mmta.mmtaid_auto
		inner join CRSF on eq.crsf_auto = CRSF.crsf_auto
		inner join CUSTOMER cust on CRSF.customer_auto = cust.customer_auto
		inner join GENERAL_EQ_UNIT geu ON geu.equipmentid_auto = eq.equipmentid_auto
		inner join TRACK_INSPECTION_DETAIL tid ON geu.equnit_auto = tid.track_unit_auto
		inner join TRACK_INSPECTION ti ON ti.inspection_auto= tid.inspection_auto
	where cust.customer_auto = case when @customer_auto=0 or @customer_auto is null then cust.customer_auto
					else @customer_auto end
		and crsf.crsf_auto = case when @crsf_auto=0 or @crsf_auto is null then crsf.crsf_auto
					else @crsf_auto end
		and eq.serialno like case when @serialno='' or @serialno is null then '%'
					else @serialno + '%' end

		and len(isnull(ti.last_interp_user,'')) > case when @status=1 then 0 else -1 end
		--and len(isnull(ti.last_interp_user,'')) < case when @status=2 then 1 else 100 end		
		and len(ISNULL(CONVERT(VarChar(60), ti.released_date, 121), '')) > case when @status=1 then 0 else -1 end
		and len(ISNULL(CONVERT(VarChar(60), ti.released_date, 121), '')) < case when @status=2 then 1 else 100 end

		and mmta.make_auto = case when @make_auto=0 or @make_auto is null then mmta.make_auto else @make_auto end
		and mmta.type_auto = case when @type_auto=0 or @type_auto is null then mmta.type_auto else @type_auto end
		and mmta.model_auto = case when @model_auto=0 or @model_auto is null then mmta.model_auto else @model_auto end
		and ti.inspection_date >= case when @start_date is null then '1900-01-01' else @start_date end
		and ti.inspection_date <= case when @end_date is null then '2200-01-01' else @end_date end 
		and ti.evalcode != case when @incl_evalA != 1 or @incl_evalA is null then 'A' else '0' end
		and ti.evalcode != case when @incl_evalB != 1 or @incl_evalB is null then 'B' else '0' end
		and ti.evalcode != case when @incl_evalC != 1 or @incl_evalC is null then 'C' else '0' end 
		and ti.evalcode != case when @incl_evalX != 1 or @incl_evalX is null then 'X' else '0' end
		--and eq.equipmentid_auto IN (SELECT * FROM dbo.fnEquipment(@user_auto))

	if exists (SELECT * 
			FROM sysobjects 
			WHERE id=object_id('#tTB_rtn_track_inp') AND OBJECTPROPERTY(id,'IsUserTable')=1)
		drop table #tTB_rtn_track_inp


	select distinct ti.inspection_auto, cust.cust_name, eq.serialno,ti.inspection_date , ti.evalcode, case when ti.released_date is null then 0 else 1 end as released, ti.eval_comment,eq.unitno, eq.equipmentid_auto
	into #tTB_rtn_track_inp
	from 
		EQUIPMENT eq
		inner join LU_MMTA mmta on eq.mmtaid_auto = mmta.mmtaid_auto
		inner join CRSF on eq.crsf_auto = CRSF.crsf_auto
		inner join CUSTOMER cust on CRSF.customer_auto = cust.customer_auto
		inner join GENERAL_EQ_UNIT geu ON geu.equipmentid_auto = eq.equipmentid_auto
		inner join TRACK_INSPECTION_DETAIL tid ON geu.equnit_auto = tid.track_unit_auto
		inner join TRACK_INSPECTION ti ON ti.inspection_auto= tid.inspection_auto
	where cust.customer_auto = case when @customer_auto=0 or @customer_auto is null then cust.customer_auto
					else @customer_auto end
		and crsf.crsf_auto = case when @crsf_auto=0 or @crsf_auto is null then crsf.crsf_auto
					else @crsf_auto end
		and eq.serialno like case when @serialno='' or @serialno is null then '%'
					else @serialno + '%' end
		and len(isnull(ti.last_interp_user,'')) > case when @status=1 then 0 else -1 end
		--and len(isnull(ti.last_interp_user,'')) < case when @status=2 then 1 else 100 end		
		and len(ISNULL(CONVERT(VarChar(60), ti.released_date, 121), '')) > case when @status=1 then 0 else -1 end
		and len(ISNULL(CONVERT(VarChar(60), ti.released_date, 121), '')) < case when @status=2 then 1 else 100 end
		and mmta.make_auto = case when @make_auto=0 or @make_auto is null then mmta.make_auto else @make_auto end
		and mmta.type_auto = case when @type_auto=0 or @type_auto is null then mmta.type_auto else @type_auto end
		and mmta.model_auto = case when @model_auto=0 or @model_auto is null then mmta.model_auto else @model_auto end
		and ti.inspection_date >= case when @start_date is null then '1900-01-01' else @start_date end
		and ti.inspection_date <= case when @end_date is null then '2200-01-01' else @end_date end 
		and ti.evalcode != case when @incl_evalA != 1 or @incl_evalA is null then 'A' else '0' end
		and ti.evalcode != case when @incl_evalB != 1 or @incl_evalB is null then 'B' else '0' end
		and ti.evalcode != case when @incl_evalC != 1 or @incl_evalC is null then 'C' else '0' end 
		and ti.evalcode != case when @incl_evalX != 1 or @incl_evalX is null then 'X' else '0' end
		--and eq.equipmentid_auto IN (SELECT * FROM dbo.fnEquipment(@user_auto))
	order by  cust.cust_name asc, eq.serialno asc,  ti.inspection_date desc

	set @need_rec = (@page_no-1) * @rec_per_page	
	if(@need_rec !=0)
	begin
		SET ROWCOUNT @need_rec	
		delete from #tTB_rtn_track_inp
		where inspection_auto in 
			(select inspection_auto from  #tTB_rtn_track_inp)
	end
	SET ROWCOUNT 0

	select * from #tTB_rtn_track_inp

	drop table #tTB_rtn_track_inp
end
else
begin
	select count(distinct ti.inspection_auto)as record_no, @rec_per_page as rec_per_page
	from 
		EQUIPMENT eq
		inner join LU_MMTA mmta on eq.mmtaid_auto = mmta.mmtaid_auto
		inner join CRSF on eq.crsf_auto = CRSF.crsf_auto
		inner join CUSTOMER cust on CRSF.customer_auto = cust.customer_auto
		inner join GENERAL_EQ_UNIT geu ON geu.equipmentid_auto = eq.equipmentid_auto
		inner join TRACK_INSPECTION_DETAIL tid ON geu.equnit_auto = tid.track_unit_auto
		inner join TRACK_INSPECTION ti ON ti.inspection_auto= tid.inspection_auto
	where cust.customer_auto = case when @customer_auto=0 or @customer_auto is null then cust.customer_auto
					else @customer_auto end
		and crsf.crsf_auto = case when @crsf_auto=0 or @crsf_auto is null then crsf.crsf_auto
					else @crsf_auto end
		and eq.serialno like case when @serialno='' or @serialno is null then '%'
					else @serialno + '%' end
		and len(isnull(ti.last_interp_user,'')) > case when @status=1 then 0 else -1 end
		--and len(isnull(ti.last_interp_user,'')) < case when @status=2 then 1 else 100 end		
		and len(ISNULL(CONVERT(VarChar(60), ti.released_date, 121), '')) > case when @status=1 then 0 else -1 end
		and len(ISNULL(CONVERT(VarChar(60), ti.released_date, 121), '')) < case when @status=2 then 1 else 100 end
		and mmta.make_auto = case when @make_auto=0 or @make_auto is null then mmta.make_auto else @make_auto end
		and mmta.type_auto = case when @type_auto=0 or @type_auto is null then mmta.type_auto else @type_auto end
		and mmta.model_auto = case when @model_auto=0 or @model_auto is null then mmta.model_auto else @model_auto end
		and ti.inspection_date >= case when @start_date is null then '1900-01-01' else @start_date end
		and ti.inspection_date <= case when @end_date is null then '2200-01-01' else @end_date end 
		and ti.evalcode != case when @incl_evalA != 1 or @incl_evalA is null then 'A' else '0' end
		and ti.evalcode != case when @incl_evalB != 1 or @incl_evalB is null then 'B' else '0' end
		and ti.evalcode != case when @incl_evalC != 1 or @incl_evalC is null then 'C' else '0' end 
		and ti.evalcode != case when @incl_evalX != 1 or @incl_evalX is null then 'X' else '0' end

	if exists (SELECT * 
			FROM sysobjects 
			WHERE id=object_id('#tTB_rtn_track_inp2') AND OBJECTPROPERTY(id,'IsUserTable')=1)
		drop table #tTB_rtn_track_inp2


	select distinct ti.inspection_auto, cust.cust_name, equip.serialno,ti.inspection_date , ti.evalcode, case when ti.released_date is null then 0 else 1 end as released, ti.eval_comment,equip.unitno, equip.equipmentid_auto
	into #tTB_rtn_track_inp2
	from 
		EQUIPMENT equip
		inner join LU_MMTA mmta on equip.mmtaid_auto = mmta.mmtaid_auto
		inner join CRSF on equip.crsf_auto = CRSF.crsf_auto
		inner join CUSTOMER cust on CRSF.customer_auto = cust.customer_auto
		inner join GENERAL_EQ_UNIT geu ON geu.equipmentid_auto = equip.equipmentid_auto
		inner join TRACK_INSPECTION_DETAIL tid ON geu.equnit_auto = tid.track_unit_auto
		inner join TRACK_INSPECTION ti ON ti.inspection_auto= tid.inspection_auto
	where cust.customer_auto = case when @customer_auto=0 or @customer_auto is null then cust.customer_auto
					else @customer_auto end
		and crsf.crsf_auto = case when @crsf_auto=0 or @crsf_auto is null then crsf.crsf_auto
					else @crsf_auto end
		and equip.serialno like case when @serialno='' or @serialno is null then '%'
					else @serialno + '%' end
		and len(isnull(ti.last_interp_user,'')) > case when @status=1 then 0 else -1 end
		--and len(isnull(ti.last_interp_user,'')) < case when @status=2 then 1 else 100 end		
		and len(ISNULL(CONVERT(VarChar(60), ti.released_date, 121), '')) > case when @status=1 then 0 else -1 end
		and len(ISNULL(CONVERT(VarChar(60), ti.released_date, 121), '')) < case when @status=2 then 1 else 100 end
		and mmta.make_auto = case when @make_auto=0 or @make_auto is null then mmta.make_auto else @make_auto end
		and mmta.type_auto = case when @type_auto=0 or @type_auto is null then mmta.type_auto else @type_auto end
		and mmta.model_auto = case when @model_auto=0 or @model_auto is null then mmta.model_auto else @model_auto end
		and ti.inspection_date >= case when @start_date is null then '1900-01-01' else @start_date end
		and ti.inspection_date <= case when @end_date is null then '2200-01-01' else @end_date end 
		and ti.evalcode != case when @incl_evalA != 1 or @incl_evalA is null then 'A' else '0' end
		and ti.evalcode != case when @incl_evalB != 1 or @incl_evalB is null then 'B' else '0' end
		and ti.evalcode != case when @incl_evalC != 1 or @incl_evalC is null then 'C' else '0' end 
		and ti.evalcode != case when @incl_evalX != 1 or @incl_evalX is null then 'X' else '0' end
	order by  cust.cust_name asc, equip.serialno asc,  ti.inspection_date desc

	set @need_rec = (@page_no-1) * @rec_per_page	

	if(@need_rec !=0)
	begin
		SET ROWCOUNT @need_rec	
		delete from #tTB_rtn_track_inp2
		where inspection_auto in 
			(select inspection_auto from  #tTB_rtn_track_inp2)
	end

	SET ROWCOUNT 0

	select * from #tTB_rtn_track_inp2

	drop table #tTB_rtn_track_inp2
end

");
        }
        
        public override void Down()
        {
            Sql(@"

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[return_track_interpretation_4T]
	@customer_auto	bigint,
	@crsf_auto		bigint,
	@serialno		varchar(50),
	@status			int, -- 0 all; 1 Interpretated; 2 not Interpretated
	@make_auto		int,
	@type_auto		int,
	@model_auto		int,
	@start_date		DateTime,
	@end_date		DateTime,
	@incl_evalA		bit,
	@incl_evalB		bit,
	@incl_evalC		bit,
	@incl_evalX		bit,
	@page_no		int,
	@rec_per_page	int,
	@user_auto		bigint
as
declare @need_rec int
set @need_rec = @page_no * @rec_per_page	
if dbo.fn_return_internal_emp_status(@user_auto) = 0
begin
	select count(distinct ti.inspection_auto)as record_no, @rec_per_page as rec_per_page
	from 
		EQUIPMENT eq
		inner join LU_MMTA mmta on eq.mmtaid_auto = mmta.mmtaid_auto
		inner join CRSF on eq.crsf_auto = CRSF.crsf_auto
		inner join CUSTOMER cust on CRSF.customer_auto = cust.customer_auto
		inner join GENERAL_EQ_UNIT geu ON geu.equipmentid_auto = eq.equipmentid_auto
		inner join TRACK_INSPECTION_DETAIL tid ON geu.equnit_auto = tid.track_unit_auto
		inner join TRACK_INSPECTION ti ON ti.inspection_auto= tid.inspection_auto
	where cust.customer_auto = case when @customer_auto=0 or @customer_auto is null then cust.customer_auto
					else @customer_auto end
		and crsf.crsf_auto = case when @crsf_auto=0 or @crsf_auto is null then crsf.crsf_auto
					else @crsf_auto end
		and eq.serialno like case when @serialno='' or @serialno is null then '%'
					else @serialno + '%' end

		and len(isnull(ti.last_interp_user,'')) > case when @status=1 then 0 else -1 end
		--and len(isnull(ti.last_interp_user,'')) < case when @status=2 then 1 else 100 end		
		and len(ISNULL(CONVERT(VarChar(60), ti.released_date, 121), '')) > case when @status=1 then 0 else -1 end
		and len(ISNULL(CONVERT(VarChar(60), ti.released_date, 121), '')) < case when @status=2 then 1 else 100 end

		and mmta.make_auto = case when @make_auto=0 or @make_auto is null then mmta.make_auto else @make_auto end
		and mmta.type_auto = case when @type_auto=0 or @type_auto is null then mmta.type_auto else @type_auto end
		and mmta.model_auto = case when @model_auto=0 or @model_auto is null then mmta.model_auto else @model_auto end
		and ti.inspection_date >= case when @start_date is null then '1900-01-01' else @start_date end
		and ti.inspection_date <= case when @end_date is null then '2200-01-01' else @end_date end 
		and ti.evalcode != case when @incl_evalA != 1 or @incl_evalA is null then 'A' else '0' end
		and ti.evalcode != case when @incl_evalB != 1 or @incl_evalB is null then 'B' else '0' end
		and ti.evalcode != case when @incl_evalC != 1 or @incl_evalC is null then 'C' else '0' end 
		and ti.evalcode != case when @incl_evalX != 1 or @incl_evalX is null then 'X' else '0' end
		and eq.equipmentid_auto IN (SELECT * FROM dbo.fnEquipment(@user_auto))

	if exists (SELECT * 
			FROM sysobjects 
			WHERE id=object_id('#tTB_rtn_track_inp') AND OBJECTPROPERTY(id,'IsUserTable')=1)
		drop table #tTB_rtn_track_inp


	select distinct ti.inspection_auto, cust.cust_name, eq.serialno,ti.inspection_date , ti.evalcode, case when ti.released_date is null then 0 else 1 end as released, ti.eval_comment,eq.unitno, eq.equipmentid_auto
	into #tTB_rtn_track_inp
	from 
		EQUIPMENT eq
		inner join LU_MMTA mmta on eq.mmtaid_auto = mmta.mmtaid_auto
		inner join CRSF on eq.crsf_auto = CRSF.crsf_auto
		inner join CUSTOMER cust on CRSF.customer_auto = cust.customer_auto
		inner join GENERAL_EQ_UNIT geu ON geu.equipmentid_auto = eq.equipmentid_auto
		inner join TRACK_INSPECTION_DETAIL tid ON geu.equnit_auto = tid.track_unit_auto
		inner join TRACK_INSPECTION ti ON ti.inspection_auto= tid.inspection_auto
	where cust.customer_auto = case when @customer_auto=0 or @customer_auto is null then cust.customer_auto
					else @customer_auto end
		and crsf.crsf_auto = case when @crsf_auto=0 or @crsf_auto is null then crsf.crsf_auto
					else @crsf_auto end
		and eq.serialno like case when @serialno='' or @serialno is null then '%'
					else @serialno + '%' end
		and len(isnull(ti.last_interp_user,'')) > case when @status=1 then 0 else -1 end
		--and len(isnull(ti.last_interp_user,'')) < case when @status=2 then 1 else 100 end		
		and len(ISNULL(CONVERT(VarChar(60), ti.released_date, 121), '')) > case when @status=1 then 0 else -1 end
		and len(ISNULL(CONVERT(VarChar(60), ti.released_date, 121), '')) < case when @status=2 then 1 else 100 end
		and mmta.make_auto = case when @make_auto=0 or @make_auto is null then mmta.make_auto else @make_auto end
		and mmta.type_auto = case when @type_auto=0 or @type_auto is null then mmta.type_auto else @type_auto end
		and mmta.model_auto = case when @model_auto=0 or @model_auto is null then mmta.model_auto else @model_auto end
		and ti.inspection_date >= case when @start_date is null then '1900-01-01' else @start_date end
		and ti.inspection_date <= case when @end_date is null then '2200-01-01' else @end_date end 
		and ti.evalcode != case when @incl_evalA != 1 or @incl_evalA is null then 'A' else '0' end
		and ti.evalcode != case when @incl_evalB != 1 or @incl_evalB is null then 'B' else '0' end
		and ti.evalcode != case when @incl_evalC != 1 or @incl_evalC is null then 'C' else '0' end 
		and ti.evalcode != case when @incl_evalX != 1 or @incl_evalX is null then 'X' else '0' end
		and eq.equipmentid_auto IN (SELECT * FROM dbo.fnEquipment(@user_auto))
	order by  cust.cust_name asc, eq.serialno asc,  ti.inspection_date desc

	set @need_rec = (@page_no-1) * @rec_per_page	
	if(@need_rec !=0)
	begin
		SET ROWCOUNT @need_rec	
		delete from #tTB_rtn_track_inp
		where inspection_auto in 
			(select inspection_auto from  #tTB_rtn_track_inp)
	end
	SET ROWCOUNT 0

	select * from #tTB_rtn_track_inp

	drop table #tTB_rtn_track_inp
end
else
begin
	select count(distinct ti.inspection_auto)as record_no, @rec_per_page as rec_per_page
	from 
		EQUIPMENT eq
		inner join LU_MMTA mmta on eq.mmtaid_auto = mmta.mmtaid_auto
		inner join CRSF on eq.crsf_auto = CRSF.crsf_auto
		inner join CUSTOMER cust on CRSF.customer_auto = cust.customer_auto
		inner join GENERAL_EQ_UNIT geu ON geu.equipmentid_auto = eq.equipmentid_auto
		inner join TRACK_INSPECTION_DETAIL tid ON geu.equnit_auto = tid.track_unit_auto
		inner join TRACK_INSPECTION ti ON ti.inspection_auto= tid.inspection_auto
	where cust.customer_auto = case when @customer_auto=0 or @customer_auto is null then cust.customer_auto
					else @customer_auto end
		and crsf.crsf_auto = case when @crsf_auto=0 or @crsf_auto is null then crsf.crsf_auto
					else @crsf_auto end
		and eq.serialno like case when @serialno='' or @serialno is null then '%'
					else @serialno + '%' end
		and len(isnull(ti.last_interp_user,'')) > case when @status=1 then 0 else -1 end
		--and len(isnull(ti.last_interp_user,'')) < case when @status=2 then 1 else 100 end		
		and len(ISNULL(CONVERT(VarChar(60), ti.released_date, 121), '')) > case when @status=1 then 0 else -1 end
		and len(ISNULL(CONVERT(VarChar(60), ti.released_date, 121), '')) < case when @status=2 then 1 else 100 end
		and mmta.make_auto = case when @make_auto=0 or @make_auto is null then mmta.make_auto else @make_auto end
		and mmta.type_auto = case when @type_auto=0 or @type_auto is null then mmta.type_auto else @type_auto end
		and mmta.model_auto = case when @model_auto=0 or @model_auto is null then mmta.model_auto else @model_auto end
		and ti.inspection_date >= case when @start_date is null then '1900-01-01' else @start_date end
		and ti.inspection_date <= case when @end_date is null then '2200-01-01' else @end_date end 
		and ti.evalcode != case when @incl_evalA != 1 or @incl_evalA is null then 'A' else '0' end
		and ti.evalcode != case when @incl_evalB != 1 or @incl_evalB is null then 'B' else '0' end
		and ti.evalcode != case when @incl_evalC != 1 or @incl_evalC is null then 'C' else '0' end 
		and ti.evalcode != case when @incl_evalX != 1 or @incl_evalX is null then 'X' else '0' end

	if exists (SELECT * 
			FROM sysobjects 
			WHERE id=object_id('#tTB_rtn_track_inp2') AND OBJECTPROPERTY(id,'IsUserTable')=1)
		drop table #tTB_rtn_track_inp2


	select distinct ti.inspection_auto, cust.cust_name, equip.serialno,ti.inspection_date , ti.evalcode, case when ti.released_date is null then 0 else 1 end as released, ti.eval_comment,equip.unitno, equip.equipmentid_auto
	into #tTB_rtn_track_inp2
	from 
		EQUIPMENT equip
		inner join LU_MMTA mmta on equip.mmtaid_auto = mmta.mmtaid_auto
		inner join CRSF on equip.crsf_auto = CRSF.crsf_auto
		inner join CUSTOMER cust on CRSF.customer_auto = cust.customer_auto
		inner join GENERAL_EQ_UNIT geu ON geu.equipmentid_auto = equip.equipmentid_auto
		inner join TRACK_INSPECTION_DETAIL tid ON geu.equnit_auto = tid.track_unit_auto
		inner join TRACK_INSPECTION ti ON ti.inspection_auto= tid.inspection_auto
	where cust.customer_auto = case when @customer_auto=0 or @customer_auto is null then cust.customer_auto
					else @customer_auto end
		and crsf.crsf_auto = case when @crsf_auto=0 or @crsf_auto is null then crsf.crsf_auto
					else @crsf_auto end
		and equip.serialno like case when @serialno='' or @serialno is null then '%'
					else @serialno + '%' end
		and len(isnull(ti.last_interp_user,'')) > case when @status=1 then 0 else -1 end
		--and len(isnull(ti.last_interp_user,'')) < case when @status=2 then 1 else 100 end		
		and len(ISNULL(CONVERT(VarChar(60), ti.released_date, 121), '')) > case when @status=1 then 0 else -1 end
		and len(ISNULL(CONVERT(VarChar(60), ti.released_date, 121), '')) < case when @status=2 then 1 else 100 end
		and mmta.make_auto = case when @make_auto=0 or @make_auto is null then mmta.make_auto else @make_auto end
		and mmta.type_auto = case when @type_auto=0 or @type_auto is null then mmta.type_auto else @type_auto end
		and mmta.model_auto = case when @model_auto=0 or @model_auto is null then mmta.model_auto else @model_auto end
		and ti.inspection_date >= case when @start_date is null then '1900-01-01' else @start_date end
		and ti.inspection_date <= case when @end_date is null then '2200-01-01' else @end_date end 
		and ti.evalcode != case when @incl_evalA != 1 or @incl_evalA is null then 'A' else '0' end
		and ti.evalcode != case when @incl_evalB != 1 or @incl_evalB is null then 'B' else '0' end
		and ti.evalcode != case when @incl_evalC != 1 or @incl_evalC is null then 'C' else '0' end 
		and ti.evalcode != case when @incl_evalX != 1 or @incl_evalX is null then 'X' else '0' end
	order by  cust.cust_name asc, equip.serialno asc,  ti.inspection_date desc

	set @need_rec = (@page_no-1) * @rec_per_page	

	if(@need_rec !=0)
	begin
		SET ROWCOUNT @need_rec	
		delete from #tTB_rtn_track_inp2
		where inspection_auto in 
			(select inspection_auto from  #tTB_rtn_track_inp2)
	end

	SET ROWCOUNT 0

	select * from #tTB_rtn_track_inp2

	drop table #tTB_rtn_track_inp2
end

");
        }
    }
}
