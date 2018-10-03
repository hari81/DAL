using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace DAL.TestDbset
{
    public class TestDbSet<TEntity> : DbSet<TEntity>, IQueryable, IEnumerable<TEntity>, IDbAsyncEnumerable<TEntity>
        where TEntity : class
    {
        ObservableCollection<TEntity> _data;
        IQueryable _query;
        public TestDbSet()
        {
            _data = new Seed<TEntity>().getCollection(); //ObservableCollection<TEntity>();
            _query = _data.AsQueryable();
        }
        /// <summary>
        /// Warning: If the first field in the list is not Key element it cannot find it! 
        /// Tries to find the element based on the first field only
        /// </summary>
        /// <param name="keyValues"></param>
        /// <returns></returns>
        public override TEntity Find(params object[] keyValues)
        {
            var id = (int)keyValues.Single();
            try
            {
                var dataTable = _data.ToList().ToDataTable();
                var dataEnumerable = dataTable.AsEnumerable();
                var items = dataEnumerable.Where(m => (long)m[0] == id);
                var itemIndex = dataTable.Rows.IndexOf(items.FirstOrDefault());
                return _data[itemIndex];
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                return null;
            }
        }
        public override TEntity Add(TEntity item)
        {
            _data.Add(item);
            return item;
        }

        public override TEntity Remove(TEntity item)
        {
            _data.Remove(item);
            return item;
        }

        public override TEntity Attach(TEntity item)
        {
            _data.Add(item);
            return item;
        }

        public override TEntity Create()
        {
            return Activator.CreateInstance<TEntity>();
        }

        public override TDerivedEntity Create<TDerivedEntity>()
        {
            return Activator.CreateInstance<TDerivedEntity>();
        }

        public override ObservableCollection<TEntity> Local
        {
            get { return _data; }
        }

        Type IQueryable.ElementType
        {
            get { return _query.ElementType; }
        }

        Expression IQueryable.Expression
        {
            get { return _query.Expression; }
        }

        IQueryProvider IQueryable.Provider
        {
            get { return new TestDbAsyncQueryProvider<TEntity>(_query.Provider); }
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return _data.GetEnumerator();
        }

        IEnumerator<TEntity> IEnumerable<TEntity>.GetEnumerator()
        {
            return _data.GetEnumerator();
        }

        IDbAsyncEnumerator<TEntity> IDbAsyncEnumerable<TEntity>.GetAsyncEnumerator()
        {
            return new TestDbAsyncEnumerator<TEntity>(_data.GetEnumerator());
        }
    }

    internal class TestDbAsyncQueryProvider<TEntity> : IDbAsyncQueryProvider
    {
        private readonly IQueryProvider _inner;

        internal TestDbAsyncQueryProvider(IQueryProvider inner)
        {
            _inner = inner;
        }

        public IQueryable CreateQuery(Expression expression)
        {
            return new TestDbAsyncEnumerable<TEntity>(expression);
        }

        public IQueryable<TElement> CreateQuery<TElement>(Expression expression)
        {
            return new TestDbAsyncEnumerable<TElement>(expression);
        }

        public object Execute(Expression expression)
        {
            return _inner.Execute(expression);
        }

        public TResult Execute<TResult>(Expression expression)
        {
            return _inner.Execute<TResult>(expression);
        }

        public Task<object> ExecuteAsync(Expression expression, CancellationToken cancellationToken)
        {
            return Task.FromResult(Execute(expression));
        }

        public Task<TResult> ExecuteAsync<TResult>(Expression expression, CancellationToken cancellationToken)
        {
            return Task.FromResult(Execute<TResult>(expression));
        }
    }

    internal class TestDbAsyncEnumerable<T> : EnumerableQuery<T>, IDbAsyncEnumerable<T>, IQueryable<T>
    {
        public TestDbAsyncEnumerable(IEnumerable<T> enumerable)
            : base(enumerable)
        { }

        public TestDbAsyncEnumerable(Expression expression)
            : base(expression)
        { }

        public IDbAsyncEnumerator<T> GetAsyncEnumerator()
        {
            return new TestDbAsyncEnumerator<T>(this.AsEnumerable().GetEnumerator());
        }

        IDbAsyncEnumerator IDbAsyncEnumerable.GetAsyncEnumerator()
        {
            return GetAsyncEnumerator();
        }

        IQueryProvider IQueryable.Provider
        {
            get { return new TestDbAsyncQueryProvider<T>(this); }
        }
    }

    internal class TestDbAsyncEnumerator<T> : IDbAsyncEnumerator<T>
    {
        private readonly IEnumerator<T> _inner;

        public TestDbAsyncEnumerator(IEnumerator<T> inner)
        {
            _inner = inner;
        }

        public void Dispose()
        {
            _inner.Dispose();
        }

        public Task<bool> MoveNextAsync(CancellationToken cancellationToken)
        {
            return Task.FromResult(_inner.MoveNext());
        }

        public T Current
        {
            get { return _inner.Current; }
        }

        object IDbAsyncEnumerator.Current
        {
            get { return Current; }
        }
    }
    public static class DataTableExtensions
    {
        public static DataTable ToDataTable<T>(this List<T> items)
        {
            var tb = new DataTable(typeof(T).Name);

            PropertyInfo[] props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);

            foreach (var prop in props)
            {
                tb.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
            }

            foreach (var item in items)
            {
                var values = new object[props.Length];
                for (var i = 0; i < props.Length; i++)
                {
                    values[i] = props[i].GetValue(item, null);
                }

                tb.Rows.Add(values);
            }

            return tb;
        }
    }

    public class Seed<TEntity> where TEntity : class
    {
        ObservableCollection<TEntity> _data = new ObservableCollection<TEntity>();
        IUndercarriageContext _realContext = new DAL.UndercarriageContext();
        public ObservableCollection<TEntity> getCollection()
        {
            string ClassName = typeof(TEntity).Name;
            switch (ClassName)
            {
                case "EQUIPMENT":
                    getEquipmentSeed();
                    break;
                case "COMPART_MEASUREMENT_POINT":
                    get_COMPART_MEASUREMENT_POINT_Seed();
                    break;
                case "CUSTOMER_MODEL_COMPARTTYPE_ADDITIONAL":
                    get_CUSTOMER_MODEL_COMPARTTYPE_ADDITIONAL_Seed();
                    break;
                case "COMPARTTYPE_ADDITIONAL_POSSIBLE_TOOLS":
                    get_COMPARTTYPE_ADDITIONAL_POSSIBLE_TOOLS_Seed();
                    break;
                case "CUSTOMER_MODEL_COMPARTTYPE_MANDATORY_IMAGE":
                    get_CUSTOMER_MODEL_COMPARTTYPE_MANDATORY_IMAGE_Seed();
                    break;
                case "COMPARTTYPE_ADDITIONAL_TYPE":
                    get_COMPARTTYPE_ADDITIONAL_TYPE_Seed();
                    break;
                case "CUSTOMER_MODEL_MANDATORY_IMAGE":
                    get_CUSTOMER_MODEL_MANDATORY_IMAGE_Seed();
                    break;
                case "APPLICATION_LU_CONFIG":
                    get_APPLICATION_LU_CONFIG_Seed();
                    break;
                case "LU_COMPART":
                    get_LU_COMPART_Seed();
                    break;
                case "LU_COMPART_PARTS":
                    get_LU_COMPART_PARTS_Seed();
                    break;
                case "LU_COMPART_TYPE":
                    get_LU_COMPART_TYPE_Seed();
                    break;
                case "MAKE":
                    get_MAKE_Seed();
                    break;
                case "MODEL":
                    get_MODEL_Seed();
                    break;
                case "TRACK_COMPART_EXT":
                    get_TRACK_COMPART_EXT_Seed();
                    break;
                case "TRACK_COMPART_WORN_CALC_METHOD":
                    get_TRACK_COMPART_WORN_CALC_METHOD_Seed();
                    break;
                case "TRACK_COMPART_WORN_LIMIT_CAT":
                    get_TRACK_COMPART_WORN_LIMIT_CAT_Seed();
                    break;
                case "TRACK_COMPART_WORN_LIMIT_HITACHI":
                    get_TRACK_COMPART_WORN_LIMIT_HITACHI_Seed();
                    break;
                case "TRACK_COMPART_WORN_LIMIT_ITM":
                    get_TRACK_COMPART_WORN_LIMIT_ITM_Seed();
                    break;
                case "TRACK_COMPART_WORN_LIMIT_KOMATSU":
                    get_TRACK_COMPART_WORN_LIMIT_KOMATSU_Seed();
                    break;
                case "TRACK_COMPART_WORN_LIMIT_LIEBHERR":
                    get_TRACK_COMPART_WORN_LIMIT_LIEBHERR_Seed();
                    break;
                case "TRACK_TOOL":
                    get_TRACK_TOOL_Seed();
                    break;
                case "TYPE":
                    get_TYPE_Seed();
                    break;
                case "USER_TABLE":
                    get_USER_TABLE_Seed();
                    break;
                case "FLUID_REPORT_LU_REPORTS":
                    get_FLUID_REPORT_LU_REPORTS_Seed();
                    break;
                case "DealershipReports":
                    get_DealershipReports_Seed();
                    break;
                case "CustomerReports":
                    get_CustomerReports_Seed();
                    break;
                case "TRACK_COMPART_MODEL_MAPPING":
                    get_TRACK_COMPART_MODEL_MAPPING_Seed();
                    break;
                case "SHOE_SIZE":
                    get_SHOE_SIZE_Seed();
                    break;
                case "SystemModelTemplate":
                    get_SystemModelTemplate_Seed();
                    break;
                case "SystemFamilyTemplate":
                    get_SystemFamilyTemplate_Seed();
                    break;
                default:
                    break;
            }
            return _data;
        }
        private void getEquipmentSeed()
        {
            var equipmentList = new List<DAL.EQUIPMENT>();
            equipmentList.Add(
                new DAL.EQUIPMENT
                {
                    equipmentid_auto = 1,
                    crsf_auto = 1,
                    serialno = "EquipmentSerial",
                    unitno = "EquipmentUnit",
                    mmtaid_auto = 1,
                    measure_unit = 1,
                    op_hrs_per_day = 8,
                    op_dist_uom = 0,
                    op_range = "DEFAULT",
                    smu_at_start = 1000,
                    distance_at_start = 0,
                    smu_at_end = 100000,
                    distance_at_end = 100000,
                    currentsmu = 1000,
                    currentdistance = 0,
                    last_reading_date = DateTime.Now.ToLocalTime(),
                    LTD_at_start = 2000,
                    purchase_op_hrs = 0,
                    purchase_date = new DateTime(2018, 1, 1, new CultureInfo("en-AU").DateTimeFormat.Calendar),
                    created_date = DateTime.Now.ToLocalTime(),
                    created_user = "TestAddEquipment",
                    modified_date = DateTime.Now.ToLocalTime(),
                    modified_user = "Not Modified",
                    equip_status = 1,
                    update_accept = true,
                    da_inclusion = true,
                });
            _data = new ObservableCollection<TEntity>(equipmentList as List<TEntity>);
        }
        private void get_COMPART_MEASUREMENT_POINT_Seed() {
            var COMPART_MEASUREMENT_POINTList = new List<DAL.COMPART_MEASUREMENT_POINT>();
            COMPART_MEASUREMENT_POINTList.AddRange(_realContext.COMPART_MEASUREMENT_POINT);
            _data = new ObservableCollection<TEntity>(COMPART_MEASUREMENT_POINTList as List<TEntity>);
        }
        private void get_CUSTOMER_MODEL_COMPARTTYPE_ADDITIONAL_Seed() {
            var _List = new List<DAL.CUSTOMER_MODEL_COMPARTTYPE_ADDITIONAL>();
            _List.AddRange(_realContext.CUSTOMER_MODEL_COMPARTTYPE_ADDITIONAL);
            _data = new ObservableCollection<TEntity>(_List as List<TEntity>);
        }
        private void get_COMPARTTYPE_ADDITIONAL_POSSIBLE_TOOLS_Seed() {
            var _List = new List<DAL.COMPARTTYPE_ADDITIONAL_POSSIBLE_TOOLS>();
            _List.AddRange(_realContext.COMPARTTYPE_ADDITIONAL_POSSIBLE_TOOLS);
            _data = new ObservableCollection<TEntity>(_List as List<TEntity>);
        }
        private void get_CUSTOMER_MODEL_COMPARTTYPE_MANDATORY_IMAGE_Seed() {
            var _List = new List<DAL.CUSTOMER_MODEL_COMPARTTYPE_MANDATORY_IMAGE>();
            _List.AddRange(_realContext.CUSTOMER_MODEL_COMPARTTYPE_MANDATORY_IMAGE);
            _data = new ObservableCollection<TEntity>(_List as List<TEntity>);
        }
        private void get_COMPARTTYPE_ADDITIONAL_TYPE_Seed() {
            var _List = new List<DAL.COMPARTTYPE_ADDITIONAL_TYPE>();
            _List.AddRange(_realContext.COMPARTTYPE_ADDITIONAL_TYPE);
            _data = new ObservableCollection<TEntity>(_List as List<TEntity>);
        }
        private void get_CUSTOMER_MODEL_MANDATORY_IMAGE_Seed() {
            var _List = new List<DAL.CUSTOMER_MODEL_MANDATORY_IMAGE>();
            _List.AddRange(_realContext.CUSTOMER_MODEL_MANDATORY_IMAGE);
            _data = new ObservableCollection<TEntity>(_List as List<TEntity>);
        }
        private void get_APPLICATION_LU_CONFIG_Seed() {
            var _List = new List<DAL.APPLICATION_LU_CONFIG>();
            _List.AddRange(_realContext.APPLICATION_LU_CONFIG);
            _data = new ObservableCollection<TEntity>(_List as List<TEntity>);
        }
        private void get_LU_COMPART_Seed() {
            var _List = new List<DAL.LU_COMPART>();
            _List.AddRange(_realContext.LU_COMPART);
            _data = new ObservableCollection<TEntity>(_List as List<TEntity>);
        }
        private void get_LU_COMPART_PARTS_Seed() {
            var _List = new List<DAL.LU_COMPART_PARTS>();
            _List.AddRange(_realContext.LU_COMPART_PARTS);
            _data = new ObservableCollection<TEntity>(_List as List<TEntity>);
        }
        private void get_LU_COMPART_TYPE_Seed() {
            var _List = new List<DAL.LU_COMPART_TYPE>();
            _List.AddRange(_realContext.LU_COMPART_TYPE);
            _data = new ObservableCollection<TEntity>(_List as List<TEntity>);
        }
        private void get_MAKE_Seed() {
            var _List = new List<DAL.MAKE>();
            _List.AddRange(_realContext.MAKE);
            _data = new ObservableCollection<TEntity>(_List as List<TEntity>);
        }
        private void get_MODEL_Seed() {
            var _List = new List<DAL.MODEL>();
            _List.AddRange(_realContext.MODELs);
            _data = new ObservableCollection<TEntity>(_List as List<TEntity>);
        }
        private void get_TRACK_COMPART_EXT_Seed() {
            var _List = new List<DAL.TRACK_COMPART_EXT>();
            _List.AddRange(_realContext.TRACK_COMPART_EXT);
            _data = new ObservableCollection<TEntity>(_List as List<TEntity>);
        }
        private void get_TRACK_COMPART_WORN_CALC_METHOD_Seed()
        {
            var _List = new List<DAL.TRACK_COMPART_WORN_CALC_METHOD>();
            _List.AddRange(_realContext.TRACK_COMPART_WORN_CALC_METHOD);
            _data = new ObservableCollection<TEntity>(_List as List<TEntity>);
        }
        private void get_TRACK_COMPART_WORN_LIMIT_CAT_Seed()
        {
            var _List = new List<DAL.TRACK_COMPART_WORN_LIMIT_CAT>();
            _List.AddRange(_realContext.TRACK_COMPART_WORN_LIMIT_CAT);
            _data = new ObservableCollection<TEntity>(_List as List<TEntity>);
        }
        private void get_TRACK_COMPART_WORN_LIMIT_HITACHI_Seed()
        {
            var _List = new List<DAL.TRACK_COMPART_WORN_LIMIT_HITACHI>();
            _List.AddRange(_realContext.TRACK_COMPART_WORN_LIMIT_HITACHI);
            _data = new ObservableCollection<TEntity>(_List as List<TEntity>);
        }
        private void get_TRACK_COMPART_WORN_LIMIT_ITM_Seed()
        {
            var _List = new List<DAL.TRACK_COMPART_WORN_LIMIT_ITM>();
            _List.AddRange(_realContext.TRACK_COMPART_WORN_LIMIT_ITM);
            _data = new ObservableCollection<TEntity>(_List as List<TEntity>);
        }
        private void get_TRACK_COMPART_WORN_LIMIT_KOMATSU_Seed()
        {
            var _List = new List<DAL.TRACK_COMPART_WORN_LIMIT_KOMATSU>();
            _List.AddRange(_realContext.TRACK_COMPART_WORN_LIMIT_KOMATSU);
            _data = new ObservableCollection<TEntity>(_List as List<TEntity>);
        }
        private void get_TRACK_COMPART_WORN_LIMIT_LIEBHERR_Seed()
        {
            var _List = new List<DAL.TRACK_COMPART_WORN_LIMIT_LIEBHERR>();
            _List.AddRange(_realContext.TRACK_COMPART_WORN_LIMIT_LIEBHERR);
            _data = new ObservableCollection<TEntity>(_List as List<TEntity>);
        }

        private void get_TRACK_TOOL_Seed()
        {
            var _List = new List<DAL.TRACK_TOOL>();
            _List.AddRange(_realContext.TRACK_TOOL);
            _data = new ObservableCollection<TEntity>(_List as List<TEntity>);
        }

        private void get_TYPE_Seed()
        {
            var _List = new List<DAL.TYPE>();
            _List.AddRange(_realContext.TYPEs);
            _data = new ObservableCollection<TEntity>(_List as List<TEntity>);
        }
        private void get_USER_TABLE_Seed()
        {
            var _List = new List<DAL.USER_TABLE>();
            _List.AddRange(_realContext.USER_TABLE);
            _data = new ObservableCollection<TEntity>(_List as List<TEntity>);
        }

        public void get_FLUID_REPORT_LU_REPORTS_Seed()
        {
            var _List = new List<DAL.FLUID_REPORT_LU_REPORTS>();
            _List.AddRange(_realContext.FLUID_REPORT_LU_REPORTS);
            _data = new ObservableCollection<TEntity>(_List as List<TEntity>);
        }

        public void get_DealershipReports_Seed()
        {
            var _List = new List<DAL.DealershipReports>();
            _List.AddRange(_realContext.DealershipReports);
            _data = new ObservableCollection<TEntity>(_List as List<TEntity>);
        }

        public void get_CustomerReports_Seed() {
            var _List = new List<DAL.CustomerReports>();
            _List.AddRange(_realContext.CustomerReports);
            _data = new ObservableCollection<TEntity>(_List as List<TEntity>);
        }
        public void get_TRACK_COMPART_MODEL_MAPPING_Seed() {
            var _List = new List<DAL.TRACK_COMPART_MODEL_MAPPING>();
            _List.AddRange(_realContext.TRACK_COMPART_MODEL_MAPPING);
            _data = new ObservableCollection<TEntity>(_List as List<TEntity>);
        }
        public void get_SHOE_SIZE_Seed() {
            var _List = new List<DAL.SHOE_SIZE>();
            _List.AddRange(_realContext.SHOE_SIZE);
            _data = new ObservableCollection<TEntity>(_List as List<TEntity>);
        }
        public void get_SystemModelTemplate_Seed() {
            var _List = new List<DAL.SystemModelTemplate>();
            _List.AddRange(_realContext.SystemModelTemplate);
            _data = new ObservableCollection<TEntity>(_List as List<TEntity>);
        }
        public void get_SystemFamilyTemplate_Seed() {
            var _List = new List<DAL.SystemFamilyTemplate>();
            _List.AddRange(_realContext.SystemFamilyTemplate);
            _data = new ObservableCollection<TEntity>(_List as List<TEntity>);
        }
    }
}