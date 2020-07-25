using System;
using System.Collections;
using System.Text;
using System.Reflection;

using NHibernate;
using NHibernate.Cfg;
using NHibernate.Expression;

using Inventori.DataAccess;

using System.Web.UI.WebControls;

namespace Inventori.Facade
{
    public class DataMasterMgtServices
    {
        protected ISession m_session;
        BaseDataAccess mgr;
        public DataMasterMgtServices()
        {
            m_session = NHibernateHttpModule.CurrentSession;
            mgr = new BaseDataAccess();
        }

        public IList GetAll(Type type)
        {
            //BaseDataAccess mgr = new BaseDataAccess();
            using (mgr)
                return mgr.Get(type);
        }

        public Object GetObjectById(Type type, Object id)
        {
            ////BaseDataAccess mgr = new BaseDataAccess();
            using (mgr)
                return mgr.Get(type, id);
        }

        //Added on Sunday, June 18, 2006
        public Object GetObjectByProperty(Type type, String PropertyName, Object PropertyValue)
        {
            ////BaseDataAccess mgr = new BaseDataAccess();
            using (mgr)
                return mgr.Get(type, PropertyName, PropertyValue);
        }

        public IList GetListLike(Type type, String LikeProperty, Object LikeValue)
        {
            //BaseDataAccess mgr = new BaseDataAccess();
            using (mgr)
                return mgr.GetListLikePropertyValue(type, LikeProperty, LikeValue);
        }

        public IList GetListLikeEq(Type type, String EqProperty, Object EqValue, String LikeProperty, Object LikeValue)
        {
            //BaseDataAccess mgr = new BaseDataAccess();
            using (mgr)
                return mgr.GetListLikeEqPropertyValue(type, EqProperty, EqValue, LikeProperty, LikeValue);
        }

        public IList GetListEq(Type type, String EqProperty, Object EqValue)
        {
            //BaseDataAccess mgr = new BaseDataAccess();
            using (mgr)
                return mgr.GetListByPropertyValue(type, EqProperty, EqValue);
        }

        public IList GetListEq(Type type, String EqProperty, Object EqValue, String EqProperty2, Object EqValue2)
        {
            //BaseDataAccess mgr = new BaseDataAccess();
            using (mgr)
                return mgr.GetListByPropertyValue(type, EqProperty, EqValue, EqProperty2, EqValue2);
        }

        public Boolean SaveOrUpdate(Object obj)
        {
            try
            {
                //BaseDataAccess mgr = new BaseDataAccess();
                using (mgr)
                    mgr.Save(obj);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public Boolean SavePersistence(Object obj)
        {
            try
            {
                //BaseDataAccess mgr = new BaseDataAccess();
                using (mgr)
                    mgr.SavePersistence(obj);
                return true;
            }
            catch
            {
                throw;
                return false;
            }
        }

        public Boolean UpdatePersistence(Object obj)
        {
            try
            {
                //BaseDataAccess mgr = new BaseDataAccess();
                using (mgr)
                    mgr.UpdatePersistence(obj);
                return true;
            }
            catch
            {
                throw;
                return false;
            }
        }

        public Boolean Delete(Object obj)
        {
            try
            {
                //BaseDataAccess mgr = new BaseDataAccess();
                using (mgr)
                    mgr.Delete(obj);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public IList GetSortedListLike(Type type, String LikeProperty, Object LikeValue, String sortProperty)
        {
            //BaseDataAccess mgr = new BaseDataAccess();
            using (mgr)
                return mgr.GetListLikePropertyValueSort(type, LikeProperty, LikeValue, sortProperty);
        }

        //_________ new method list sorting by asc or desc : yayang      
        public IList GetSortByListLike(Type type, String LikeProperty, Object LikeValue, String sortProperty, String sortIn)
        {
            //BaseDataAccess mgr = new BaseDataAccess();
            using (mgr)
                return mgr.GetListLikePropertyValueSortBy(type, LikeProperty, LikeValue, sortProperty, sortIn);
        }

        //Added by Yayang on June 14, 2006
        public IList GetAllSortBy(Type type, String sortProperty, String sortIn)
        {
            //BaseDataAccess mgr = new BaseDataAccess();
            using (mgr)
                return mgr.GetAllSortedListByPropertyValue(type, sortProperty, sortIn);
        }

        //Added by Andri Yadi on May 09, 2006
        public ListItemCollection GetGeneralListItemCollection(Type type, string selectString)
        {
            ListItemCollection items = new ListItemCollection();

            ListItem item = new ListItem();

            if (!String.IsNullOrEmpty(selectString))
            {
                item.Value = "";
                item.Text = selectString;
                item.Selected = true;
                items.Add(item);
            }

            //BaseDataAccess mgr = new BaseDataAccess();
            IList ReturnedList = mgr.GetSortByType(type, "Name"); // GetAll(type);

            IEnumerator en = ReturnedList.GetEnumerator();
            while (en.MoveNext())
            {
                Object obj = en.Current;

                PropertyInfo[] propsInfo = type.GetProperties();
                int i;
                for (i = 1; i < propsInfo.Length; i++)
                {
                    if (propsInfo[i].Name.ToLower() == ("Name").ToLower())
                        break;
                }
                Object val = propsInfo[i].GetValue(obj, null);
                string description = val.ToString();
                string id = (propsInfo[0].GetValue(obj, null)).ToString();
                item = new ListItem();
                item.Value = id;
                item.Text = description;
                items.Add(item);
            }

            return items;
        }

        public ListItemCollection GetGeneralListItemCollection(Type type)
        {
            return GetGeneralListItemCollection(type, "- Select Value -");
        }

        //Added by Andri Yadi on May 27, 2006
        public ListItemCollection GetGeneralListItemCollection(Type type, string selectString, string filterName, object filterValue)
        {
            ListItemCollection items = new ListItemCollection();

            ListItem item = new ListItem();

            if (!String.IsNullOrEmpty(selectString))
            {
                item.Value = "";
                item.Text = selectString;
                item.Selected = true;
                items.Add(item);
            }

            //BaseDataAccess mgr = new BaseDataAccess();
            IList ReturnedList = mgr.GetSortedListByPropertyValue(type, filterName, filterValue, "Name", "ASC");//(GetListByPropertyValue();

            IEnumerator en = ReturnedList.GetEnumerator();
            while (en.MoveNext())
            {
                Object obj = en.Current;

                PropertyInfo[] propsInfo = type.GetProperties();
                int i;
                for (i = 1; i < propsInfo.Length; i++)
                {
                    if (propsInfo[i].Name.ToLower() == ("Name").ToLower())
                        break;
                }
                Object val = propsInfo[i].GetValue(obj, null);
                string description = val.ToString();
                string id = (propsInfo[0].GetValue(obj, null)).ToString();
                item = new ListItem();
                item.Value = id;
                item.Text = description;
                items.Add(item);
            }

            return items;
        }

        public ListItemCollection GetGeneralListItemCollection(Type type, string filterName, object filterValue)
        {
            return GetGeneralListItemCollection(type, "- Select Value -", filterName, filterValue);
        }

        public int GetCount(String TypeName, String EqProperty, Object EqValue)
        {
            String queryString;
            if (!String.IsNullOrEmpty(EqProperty))
            {
                queryString = "SELECT COUNT(*) FROM {0} obj WHERE obj.{1}=:val";
                queryString = String.Format(queryString, TypeName, EqProperty);
            }
            else
            {
                queryString = "SELECT COUNT(*) FROM {0}";
                queryString = String.Format(queryString, TypeName);
            }

            IQuery query = m_session.CreateQuery(queryString);
            if (!String.IsNullOrEmpty(EqProperty))
            {
                query.SetParameter("val", EqValue);
            }

            IList list = query.List();
            if (list.Count > 0)
            {
                return Convert.ToInt32(list[0]);
            }
            return 0;
        }

        public int GetCount(String TypeName)
        {
            return GetCount(TypeName, String.Empty, null);
        }

        public IList GetListEq(Type type, String EqProperty, Object EqValue, String EqProperty2, Object EqValue2, String EqProperty3, Object EqValue3)
        {
            //BaseDataAccess mgr = new BaseDataAccess();
            using (mgr)
                return mgr.GetListByPropertyValue(type, EqProperty, EqValue, EqProperty2, EqValue2, EqProperty3, EqValue3);
        }

        public Object GetObjectByProperty(Type type, String PropertyName, Object PropertyValue, String PropertyName2, Object PropertyValue2)
        {
            //BaseDataAccess mgr = new BaseDataAccess();
            using (mgr)
                return mgr.Get(type, PropertyName, PropertyValue, PropertyName2, PropertyValue2);
        }

        public Object GetObjectByProperty(Type type, String PropertyName, Object PropertyValue, String PropertyName2, Object PropertyValue2, String PropertyName3, Object PropertyValue3)
        {
            //BaseDataAccess mgr = new BaseDataAccess();
            using (mgr)
                return mgr.Get(type, PropertyName, PropertyValue, PropertyName2, PropertyValue2, PropertyName3, PropertyValue3);

        }

        // added at 16 maret 2007 13:25
        public IList GetListNotEq(Type type, String NotEqProperty, Object NotEqValue)
        {
            //BaseDataAccess mgr = new BaseDataAccess();
            using (mgr)
                return mgr.GetListByNotPropertyValue(type, NotEqProperty, NotEqValue);
        }

        // added at 16 maret 2007 13:35
        public IList GetOrderListNotEq(Type type, string sortPropertyName, string sortDirection, String NotEqProperty, Object NotEqValue)
        {
            //BaseDataAccess mgr = new BaseDataAccess();
            using (mgr)
                return mgr.GetAllSortedListByNotPropertyValue(type, sortPropertyName, sortDirection, NotEqProperty, NotEqValue);
        }

        // added at 10 April 2007 17:25
        public IList GetListBetweenValue(Type type, string betweenPropertyName, object fromBetweenValue, object toBetweenValue)
        {
            //BaseDataAccess mgr = new BaseDataAccess();
            using (mgr)
                return mgr.GetListBetweenValue(type, betweenPropertyName, fromBetweenValue, toBetweenValue);
        }

        // added at 10 April 2007 18:54
        public IList GetListBetweenEqValue(Type type, string betweenPropertyName, object fromBetweenValue, object toBetweenValue, string eqPropertyName, object eqValue)
        {
            //BaseDataAccess mgr = new BaseDataAccess();
            using (mgr)
                return mgr.GetListBetweenEqValue(type, betweenPropertyName, fromBetweenValue, toBetweenValue, eqPropertyName, eqValue);
        }

        // added at 21 April 2007 12:49
        public IList GetListLessThan(Type type, string lessThanPropertyName, object lessThanValue)
        {
            //BaseDataAccess mgr = new BaseDataAccess();
            using (mgr)
                return mgr.GetListLessThan(type, lessThanPropertyName, lessThanValue);
        }

        // added at 8 Mei 2007 14:58
        public IList GetListBetweenEqLikeValue(Type type, string betweenPropertyName, object fromBetweenValue, object toBetweenValue, string eqPropertyName, object eqValue, string likePropertyName, object likeValue)
        {
            using (mgr)
                return mgr.GetListBetweenEqLikeValue(type, betweenPropertyName, fromBetweenValue, toBetweenValue, eqPropertyName, eqValue, likePropertyName, likeValue);
        }

        // added at 2 july 2007 07:07
        public IList GetListEqGreatThan(Type type, string eqPropertyName, object eqPropertyValue,
           string eqPropertyName2, object eqPropertyValue2,
           string greatThanPropertyName, object greatThanPropertyValue)
        {
            using (mgr)
                return mgr.GetListEqGreatThan(type, eqPropertyName, eqPropertyValue, eqPropertyName2, eqPropertyValue2, greatThanPropertyName, greatThanPropertyValue);
        }

        // added at 4 juli 2007 10:45
        public IList GetListEqNotEqLessThan(Type type, string eqPropertyName, object eqPropertyValue,
           string eqPropertyName2, object eqPropertyValue2, string notEqPropertyName, object notEqPropertyValue, string lessThanPropertyName, object lessThanValue)
        {
            using (mgr)
                return mgr.GetListEqNotEqLessThan(type, eqPropertyName, eqPropertyValue,
                eqPropertyName2, eqPropertyValue2, notEqPropertyName, notEqPropertyValue, lessThanPropertyName, lessThanValue);
        }

        // added at 15 juli 2007 9:50
        public IList GetListEqNotEqLessThan(Type type, string eqPropertyName, object eqPropertyValue,
            string notEqPropertyName, object notEqPropertyValue, string lessThanPropertyName, object lessThanValue)
        {
            using (mgr)
                return mgr.GetListEqNotEqLessThan(type, eqPropertyName, eqPropertyValue,
              notEqPropertyName, notEqPropertyValue, lessThanPropertyName, lessThanValue);
        }

        // added at 8 sep 2007 10 : 44
        public IList GetList(Type type, ICriterion[] expArrays, Order[] orderArrays)
        {
            //BaseDataAccess mgr = new BaseDataAccess();
            using (mgr)
                return mgr.GetList(type, expArrays, orderArrays);
        }
    }
}