using System;
using System.Collections;
using System.Reflection;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Expression;

namespace Inventori.DataAccess
{
    /// <summary>
    /// Summary description for BaseDataAccess.
    /// </summary>
    public class BaseDataAccess : IDisposable
    {
        //protected ISession m_session;
        protected ISession m_session
        {
            get
            {
                return NHibernateHttpModule.CurrentSession;
            }
            set
            {
                NHibernateHttpModule.CurrentSession = value;
            }
        }

        public BaseDataAccess()
        {
            //m_session = NHibernateHttpModule.CurrentSession;
        }


        public void Dispose()
        {
            //NHibernateHttpModule.CurrentSession.Dispose();
            if (m_session != null)
            {
                m_session.Flush();
                m_session.Close();
                m_session.Dispose();
            }
            m_session = null;

        }

        /// <summary>
        /// Save a collection.
        /// </summary>
        /// <param name="items"></param>
        public virtual void Save(IList items)
        {
            ITransaction tx = null;
            try
            {
                if (items != null)
                {
                    tx = m_session.BeginTransaction();

                    foreach (object item in items)
                    {
                        m_session.SaveOrUpdate(item);
                    }

                    tx.Commit();
                }
            }
            catch (Exception ex)
            {
                tx.Rollback();
                throw ex;
            }
        }

        /// <summary>
        /// Saves an item and then saves the child items inside of a transaction.
        /// </summary>
        /// <param name="parentItem"></param>
        /// <param name="childItems"></param>
        public virtual void Save(object parentItem, IList childItems)
        {
            ITransaction tx = null;
            try
            {
                if (childItems != null)
                {
                    tx = m_session.BeginTransaction();
                    m_session.SaveOrUpdate(parentItem);

                    foreach (object item in childItems)
                    {
                        m_session.SaveOrUpdate(item);
                    }

                    tx.Commit();
                }
            }
            catch (Exception ex)
            {
                tx.Rollback();
                throw ex;
            }
        }

        /// <summary>
        /// Saves the item.
        /// </summary>
        /// <param name="item"></param>
        public virtual void Save(Object item)
        {
            Save(item, true);
        }

        /// <summary>
        /// Saves the item.
        /// </summary>
        /// <param name="item"></param>
        protected virtual void Save(object item, bool pointlessParameter)
        {
            ITransaction tx = null;

            try
            {
                tx = m_session.BeginTransaction();
                m_session.SaveOrUpdate(item);
                tx.Commit();
            }
            catch (Exception ex)
            {
                if (tx != null) tx.Rollback();
                throw ex;
            }
        }

        /// <summary>
        /// Returns a list of items matching the type supplied.
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public IList Get(Type type)
        {
            return GetByType(type);
        }

        public object Get(Type type, object id)
        {
            object returnValue = null;

            try
            {
                returnValue = m_session.Load(type, id);
                return returnValue;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IList GetListByPropertyValue(Type type, string propertyName, object propertyValue)
        {
            try
            {
                ICriteria crit = m_session.CreateCriteria(type);
                crit.Add(Expression.Eq(propertyName, propertyValue));
                return crit.List();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IList GetListLikeEqPropertyValue(Type type, string EqName, object EqValue, string LikeName, object LikeValue)
        {
            try
            {
                ICriteria crit = m_session.CreateCriteria(type);
                crit.Add(Expression.InsensitiveLike(LikeName, LikeValue));
                crit.Add(Expression.Eq(EqName, EqValue));
                return crit.List();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IList GetListLikePropertyValue(Type type, string propertyName, object propertyValue)
        {
            try
            {
                ICriteria crit = m_session.CreateCriteria(type);
                crit.Add(Expression.InsensitiveLike(propertyName, propertyValue));
                return crit.List();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IList GetListLikePropertyValueSort(Type type, string propertyName, object propertyValue, string sortProperty)
        {
            try
            {
                ICriteria crit = m_session.CreateCriteria(type);
                crit.Add(Expression.InsensitiveLike(propertyName, propertyValue));
                crit.AddOrder(Order.Asc(sortProperty));
                return crit.List();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IList GetListByPropertyValue(Type type, string propertyName, object propertyValue,
            string propertyName2, object propertyValue2)
        {
            try
            {
                ICriteria crit = m_session.CreateCriteria(type);
                crit.Add(Expression.Eq(propertyName, propertyValue));
                crit.Add(Expression.Eq(propertyName2, propertyValue2));
                return crit.List();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IList GetListByPropertyValue(Type type, string propertyName, object propertyValue,
           string propertyName2, object propertyValue2,
           string propertyName3, object propertyValue3)
        {
            try
            {
                ICriteria crit = m_session.CreateCriteria(type);
                crit.Add(Expression.Eq(propertyName, propertyValue));
                crit.Add(Expression.Eq(propertyName2, propertyValue2));
                crit.Add(Expression.Eq(propertyName3, propertyValue3));
                return crit.List();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public object Get(Type type, string propertyName, object propertyValue)
        {
            try
            {
                ICriteria crit = m_session.CreateCriteria(type);
                crit.Add(Expression.Eq(propertyName, propertyValue));

                IList list = crit.List();

                if (list == null || list.Count < 1)
                {
                    return null;
                }
                else
                {
                    return list[0];
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public object Get(
            Type type,
            string propertyName, object propertyValue,
            string propertyName2, object propertyValue2)
        {
            try
            {
                ICriteria crit = m_session.CreateCriteria(type);

                crit.Add(Expression.Eq(propertyName, propertyValue));
                crit.Add(Expression.Eq(propertyName2, propertyValue2));

                IList list = crit.List();

                if (list == null || list.Count < 1)
                {
                    return null;
                }
                else
                {
                    return list[0];
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private IList GetByType(Type type)
        {
            IList items = null;
            ITransaction tx = null;

            try
            {
                tx = m_session.BeginTransaction();

                items = m_session.CreateCriteria(type).List();

                tx.Commit();

                return items;
            }
            catch (Exception ex)
            {
                if (tx != null) tx.Rollback();

                throw ex;
            }
        }

        public IList GetSortByType(Type type, String id)
        {
            IList items = null;
            ICriteria criteria = null;
            ITransaction tx = null;

            try
            {
                tx = m_session.BeginTransaction();

                criteria = m_session.CreateCriteria(type);
                criteria.AddOrder(Order.Asc(id));
                items = criteria.List();
                tx.Commit();

                return items;
            }
            catch (Exception ex)
            {
                if (tx != null) tx.Rollback();

                throw ex;
            }
        }

        public void Delete(object item)
        {
            ITransaction tx = null;

            try
            {
                tx = m_session.BeginTransaction();

                m_session.Delete(item);

                tx.Commit();
            }
            catch (Exception ex)
            {
                if (tx != null) tx.Rollback();

                throw ex;
            }
        }

        public void Delete(IList items)
        {
            ITransaction tx = null;

            try
            {
                tx = m_session.BeginTransaction();

                foreach (object item in items)
                {
                    m_session.Delete(item);
                }

                tx.Commit();
            }
            catch (Exception ex)
            {
                if (tx != null) tx.Rollback();

                throw ex;
            }
        }

        public Int32 CountData(Type type)
        {
            try
            {
                ICriteria crit = m_session.CreateCriteria(type);
                return crit.List().Count;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Int32 CountData(Type type, string propertyName, object propertyValue)
        {
            try
            {
                ICriteria crit = m_session.CreateCriteria(type);
                crit.Add(Expression.Eq(propertyName, propertyValue));

                IList list = crit.List();
                return list.Count;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Int32 CountData(Type type, string propertyName, object propertyValue, string propertyName2, object propertyValue2)
        {
            try
            {
                ICriteria crit = m_session.CreateCriteria(type);
                crit.Add(Expression.Eq(propertyName, propertyValue));
                crit.Add(Expression.Eq(propertyName2, propertyValue2));
                IList list = crit.List();
                return list.Count;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IList SelectFromToDate(Type type, string propertyType, object module, string propertyDate, object from, object to)
        {
            try
            {
                ICriteria crit = m_session.CreateCriteria(type);
                crit.Add(Expression.Eq(propertyType, module));
                crit.Add(Expression.Between(propertyDate, from, to));
                IList list = crit.List();
                return list;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public virtual void SavePersistence(Object item)
        {
            ITransaction tx = null;
            try
            {
                tx = m_session.BeginTransaction();
                m_session.Save(item);
                tx.Commit();
            }
            catch (Exception ex)
            {
                tx.Rollback();
                throw ex;
            }
        }

        public virtual void UpdatePersistence(Object item)
        {
            ITransaction tx = null;
            try
            {
                tx = m_session.BeginTransaction();
                m_session.Update(item);
                tx.Commit();
            }
            catch (Exception ex)
            {
                tx.Rollback();
                throw ex;
            }
        }

        public IList GetLimitedListLikePropertyValue(Type type, string propertyName, object propertyValue, int limit)
        {
            try
            {
                ICriteria crit = m_session.CreateCriteria(type);
                crit.SetMaxResults(limit);
                crit.Add(Expression.InsensitiveLike(propertyName, (string)propertyValue, MatchMode.Start));
                return crit.List();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IList GetLimitedSortListLikePropertyValue(Type type, string propertyName, object propertyValue, int limit, string sortProperty)
        {
            try
            {
                ICriteria crit = m_session.CreateCriteria(type);
                crit.SetMaxResults(limit);
                crit.Add(Expression.InsensitiveLike(propertyName, (string)propertyValue, MatchMode.Start));
                crit.AddOrder(Order.Asc(sortProperty));
                return crit.List();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IList GetLimitedSortListLikePropertyValueEq(Type type, string propertyName, object propertyValue, int limit, string sortProperty, string EqProperty, object EqValue)
        {
            try
            {
                ICriteria crit = m_session.CreateCriteria(type);
                crit.SetMaxResults(limit);
                crit.Add(Expression.InsensitiveLike(propertyName, (string)propertyValue, MatchMode.Start));
                crit.AddOrder(Order.Asc(sortProperty));
                crit.Add(Expression.Eq(EqProperty, EqValue));
                return crit.List();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /*___Added By sanjaya.im@gmail.com______________________________________*/
        public IList GetListLikePropertyValueSortBy(Type type, string propertyName, object propertyValue, string sortProperty, string sortIn)
        {
            try
            {
                ICriteria crit = m_session.CreateCriteria(type);
                crit.Add(Expression.InsensitiveLike(propertyName, propertyValue));
                if (sortIn.ToUpper() == "ASC")
                    crit.AddOrder(Order.Asc(sortProperty));
                else if (sortIn.ToUpper() == "DESC")
                    crit.AddOrder(Order.Desc(sortProperty));
                return crit.List();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// This Method is used to get list of type based on propertyName=propertyValue sorted by sortPropertyName with direction specified by sortDirection.
        /// Add by Andri Yadi on May 28, 2006
        /// </summary>
        /// <param name="type"></param>
        /// <param name="propertyName"></param>
        /// <param name="propertyValue"></param>
        /// <param name="sortPropertyName"></param>
        /// <param name="sortDirection"></param>
        /// <returns>Returns a List of Matched Objects</returns>
        public IList GetSortedListByPropertyValue(Type type, string propertyName, object propertyValue, string sortPropertyName, string sortDirection)
        {
            try
            {
                ICriteria crit = m_session.CreateCriteria(type);
                crit.Add(Expression.Eq(propertyName, propertyValue));

                if (sortDirection.ToUpper() == "ASC")
                    crit.AddOrder(Order.Asc(sortPropertyName));
                else if (sortDirection.ToUpper() == "DESC")
                    crit.AddOrder(Order.Desc(sortPropertyName));

                return crit.List();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IList GetAllSortedListByPropertyValue(Type type, string sortPropertyName, string sortDirection)
        {
            try
            {
                ICriteria crit = m_session.CreateCriteria(type);

                if (sortDirection.ToUpper() == "ASC")
                    crit.AddOrder(Order.Asc(sortPropertyName));
                else if (sortDirection.ToUpper() == "DESC")
                    crit.AddOrder(Order.Desc(sortPropertyName));

                return crit.List();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public object Get(
           Type type,
           string propertyName, object propertyValue,
           string propertyName2, object propertyValue2,
           string propertyName3, object propertyValue3)
        {
            try
            {
                ICriteria crit = m_session.CreateCriteria(type);

                crit.Add(Expression.Eq(propertyName, propertyValue));
                crit.Add(Expression.Eq(propertyName2, propertyValue2));
                crit.Add(Expression.Eq(propertyName3, propertyValue3));

                IList list = crit.List();

                if (list == null || list.Count < 1)
                {
                    return null;
                }
                else
                {
                    return list[0];
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // added at 16 maret 2007 13:25
        public IList GetListByNotPropertyValue(Type type, string propertyName, object propertyValue)
        {
            try
            {
                ICriteria crit = m_session.CreateCriteria(type);
                crit.Add(Expression.Not(Expression.Eq(propertyName, propertyValue)));

                return crit.List();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // added at 16 maret 2007 13:33
        public IList GetAllSortedListByNotPropertyValue(Type type, string sortPropertyName, string sortDirection, string NotEqName, object NotEqValue)
        {
            try
            {
                ICriteria crit = m_session.CreateCriteria(type);

                crit.Add(Expression.Not(Expression.Eq(NotEqName, NotEqValue)));

                if (sortDirection.ToUpper() == "ASC")
                    crit.AddOrder(Order.Asc(sortPropertyName));
                else if (sortDirection.ToUpper() == "DESC")
                    crit.AddOrder(Order.Desc(sortPropertyName));

                return crit.List();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // added at 10 April 2007 17:25
        public IList GetListBetweenValue(Type type, string betweenPropertyName, object fromBetweenValue, object toBetweenValue)
        {
            try
            {
                ICriteria crit = m_session.CreateCriteria(type);

                crit.Add(Expression.Between(betweenPropertyName, fromBetweenValue, toBetweenValue));

                return crit.List();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // added at 10 April 2007 18:53
        public IList GetListBetweenEqValue(Type type, string betweenPropertyName, object fromBetweenValue, object toBetweenValue, string eqPropertyName, object eqValue)
        {
            try
            {
                ICriteria crit = m_session.CreateCriteria(type);

                crit.Add(Expression.Between(betweenPropertyName, fromBetweenValue, toBetweenValue));
                crit.Add(Expression.Eq(eqPropertyName, eqValue));

                return crit.List();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // added at 21 April 2007 12:49
        public IList GetListLessThan(Type type, string lessThanPropertyName, object lessThanValue)
        {
            try
            {
                ICriteria crit = m_session.CreateCriteria(type);

                crit.Add(Expression.Le(lessThanPropertyName, lessThanValue));
                return crit.List();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // added at 8 Mei 2007 14:58
        public IList GetListBetweenEqLikeValue(Type type, string betweenPropertyName, object fromBetweenValue, object toBetweenValue, string eqPropertyName, object eqValue, string likePropertyName, object likeValue)
        {
            try
            {
                ICriteria crit = m_session.CreateCriteria(type);

                crit.Add(Expression.Between(betweenPropertyName, fromBetweenValue, toBetweenValue));
                crit.Add(Expression.Eq(eqPropertyName, eqValue));
                crit.Add(Expression.Like(likePropertyName, likeValue));
                return crit.List();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // added at 2 july 2007 07:07
        public IList GetListEqGreatThan(Type type, string eqPropertyName, object eqPropertyValue,
           string eqPropertyName2, object eqPropertyValue2,
           string greatThanPropertyName, object greatThanPropertyValue)
        {
            try
            {
                ICriteria crit = m_session.CreateCriteria(type);
                crit.Add(Expression.Eq(eqPropertyName, eqPropertyValue));
                crit.Add(Expression.Eq(eqPropertyName2, eqPropertyValue2));
                crit.Add(Expression.Gt(greatThanPropertyName, greatThanPropertyValue));
                return crit.List();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // added at 4 juli 2007 10:45
        public IList GetListEqNotEqLessThan(Type type, string eqPropertyName, object eqPropertyValue,
           string eqPropertyName2, object eqPropertyValue2, string notEqPropertyName, object notEqPropertyValue, string lessThanPropertyName, object lessThanValue)
        {
            try
            {
                ICriteria crit = m_session.CreateCriteria(type);
                crit.Add(Expression.Eq(eqPropertyName, eqPropertyValue));
                crit.Add(Expression.Eq(eqPropertyName2, eqPropertyValue2));
                crit.Add(Expression.Not(Expression.Eq(notEqPropertyName, notEqPropertyValue)));
                crit.Add(Expression.Lt(lessThanPropertyName, lessThanValue));
                return crit.List();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // added at 15 juli 2007 9:50
        public IList GetListEqNotEqLessThan(Type type, string eqPropertyName, object eqPropertyValue,
           string notEqPropertyName, object notEqPropertyValue, string lessThanPropertyName, object lessThanValue)
        {
            try
            {
                ICriteria crit = m_session.CreateCriteria(type);
                crit.Add(Expression.Eq(eqPropertyName, eqPropertyValue));
                crit.Add(Expression.Not(Expression.Eq(notEqPropertyName, notEqPropertyValue)));
                crit.Add(Expression.Lt(lessThanPropertyName, lessThanValue));
                return crit.List();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // added at 8 sep 2007 10 : 44
        /// <summary>
        /// GetList
        /// </summary>
        /// <param name="type"></param>
        /// <param name="expArrays"></param>
        /// <param name="orderArrays"></param>
        /// <returns></returns>
        public IList GetList(Type type, ICriterion[] expArrays, Order[] orderArrays)
        {
            try
            {
                ICriteria crit = m_session.CreateCriteria(type);

                if (orderArrays != null)
                {
                    Order ord;
                    for (int i = 0; i < orderArrays.Length; i++)
                    {
                        ord = orderArrays[i];
                        if (ord != null)
                            crit.AddOrder(ord);
                    }
                }

                if (expArrays != null)
                {
                    ICriterion creat;
                    for (int i = 0; i < expArrays.Length; i++)
                    {
                        creat = expArrays[i];
                        if (creat != null)
                            crit.Add(creat);
                    }
                }
                return crit.List();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
