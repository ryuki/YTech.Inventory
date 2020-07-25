using System;
using System.Web;
using Inventori.DataAccess;
using NHibernate;
using NHibernate.Cfg;

namespace Inventori.DataAccess
{
    /// <summary>
    /// Summary description for NHibernateHttpModule.
    /// </summary>
    public class NHibernateHttpModule : IHttpModule
    {
        // this is only used if not running in HttpModule mode
        protected static ISessionFactory m_factory;

        // this is only used if not running in HttpModule mode
        private static ISession m_session;  

        private static readonly string KEY_NHIBERNATE_FACTORY = "NHibernateSessionFactory";
        private static readonly string KEY_NHIBERNATE_SESSION = "NHibernateSession";


        public void Init(HttpApplication application)
        {
            log4net.Config.XmlConfigurator.Configure();

            application.BeginRequest += new EventHandler(context_BeginRequest);
            application.EndRequest += new EventHandler(context_EndRequest);
        }

        public void Dispose()
        {
            if (m_session != null)
            {
                m_session.Flush();
                //m_session.Close();
                m_session.Dispose();
            }

            if (m_factory != null)
            {
                m_factory.Close();
            }
        }

        private void context_BeginRequest(object sender, EventArgs e)
        {
            HttpApplication application = (HttpApplication)sender;
            HttpContext context = application.Context;

            context.Items[KEY_NHIBERNATE_SESSION] = CreateSession();
        }

        private void context_EndRequest(object sender, EventArgs e)
        {
            HttpApplication application = (HttpApplication)sender;
            HttpContext context = application.Context;

            ISession session = context.Items[KEY_NHIBERNATE_SESSION] as ISession;
            if (session != null)
            {
                try
                {
                    session.Flush();
                    session.Close();
                }
                catch { }
            }

            context.Items[KEY_NHIBERNATE_SESSION] = null;
        }

        protected static ISessionFactory CreateSessionFactory()
        {
            Configuration config;
            ISessionFactory factory;

            config = new Configuration()    ;

            if (config == null)
            {
                throw new InvalidOperationException("NHibernate configuration is null.");
            }
            config.Configure();

            //config.Properties.Add("hibernate.connection.provider", "NHibernate.Connection.DriverConnectionProvider");
            //config.Properties.Add("hibernate.connection.driver_class", "NHibernate.Driver.SqlClientDriver");

            //string ServerName = System.Configuration.ConfigurationManager.AppSettings["ServerName"].ToString();

            //string cn = "Server=" + ServerName + "\\SQLEXPRESS;initial catalog=INVENTORI;User Id=INVENTORI;Password=INVENTORI$;";

            //config.Properties.Add("hibernate.connection.connection_string", cn);

            //config.Properties.Add("hibernate.connection.isolation", "ReadCommitted");
            //config.Properties.Add("show_sql", "true");
            //config.Properties.Add("hibernate.dialect", "NHibernate.Dialect.MsSql2005Dialect");
            ////config.Properties.Add("query.substitutions", "true 1, false 0, yes 'Y', no 'N'");
            //config.AddAssembly("Inventori.Data");
            //config.AddAssembly("Inventori.Billiard.Data");

            factory = config.BuildSessionFactory();

            if (factory == null)
            {
                throw new InvalidOperationException("Call to Configuration.BuildSessionFactory() returned null.");
            }
            else
            {
                return factory;
            }
        }

        public static ISessionFactory CurrentFactory
        {
            get
            {
                if (HttpContext.Current == null)
                {
                    // running without an HttpContext (non-web mode)
                    // the nhibernate session is a singleton in the app domain
                    if (m_factory != null)
                    {
                        return m_factory;
                    }
                    else
                    {
                        m_factory = CreateSessionFactory();

                        return m_factory;
                    }
                }
                else
                {
                    // running inside of an HttpContext (web mode)
                    // the nhibernate session is a singleton to the http request
                    HttpContext currentContext = HttpContext.Current;

                    ISessionFactory factory = currentContext.Application[KEY_NHIBERNATE_FACTORY] as ISessionFactory;

                    if (factory == null)
                    {
                        factory = CreateSessionFactory();
                        currentContext.Application[KEY_NHIBERNATE_FACTORY] = factory;
                    }

                    return factory;
                }
            }
        }

        public static ISession CreateSession()
        {
            ISessionFactory factory;
            ISession session;

            factory = NHibernateHttpModule.CurrentFactory;

            if (factory == null)
            {
                throw new InvalidOperationException("Call to Configuration.BuildSessionFactory() returned null.");
            }

            session = factory.OpenSession();

            if (session == null)
            {
                throw new InvalidOperationException("Call to factory.OpenSession() returned null.");
            }

            return session;
        }

        public static ISession CurrentSession
        {
            get
            {

                if (HttpContext.Current == null)
                {
                    // running without an HttpContext (non-web mode)
                    // the nhibernate session is a singleton in the app domain
                    if (m_session != null)
                    {
                        return m_session;
                    }
                    else
                    {
                        m_session = CreateSession();

                        return m_session;
                    }
                }
                else
                {
                    // running inside of an HttpContext (web mode)
                    // the nhibernate session is a singleton to the http request
                    HttpContext currentContext = HttpContext.Current;

                    ISession session = currentContext.Items[KEY_NHIBERNATE_SESSION] as ISession;

                    if (session == null)
                    {
                        session = CreateSession();
                        currentContext.Items[KEY_NHIBERNATE_SESSION] = session;
                    }

                    return session;
                }
            }
            set
            {
                m_session = value;
            }
        }

    }

}


