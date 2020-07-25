using System;
using System.Collections.Generic;
using System.Text;

using System.ServiceProcess;

namespace Inventori.Module
{
    public class NTServiceInfo
    {
        public NTServiceInfo(string m_ServiceName, string m_MachineName)
        {
            v_ServiceName = m_ServiceName;
            v_MachineName = m_MachineName;
        }

        private string v_ServiceName;
        private string v_MachineName;

        public virtual string m_ServiceName
        {
            get { return v_ServiceName; }
            set { v_ServiceName = value; }
        }

        public virtual string m_MachineName
        {
            get { return v_MachineName; }
            set { v_MachineName = value; }
        }


        public bool RestartServervice(bool ToDebug,
                 out string ErrorInfo)
        {
            try
            {
                ErrorInfo = "";

                if (this.StopService(ToDebug, out ErrorInfo))
                {
                    if (this.StartService(ToDebug, out ErrorInfo))
                    { return true; }
                    else { return false; }
                }
                else
                { return false; }

            }
            catch (Exception ex_restart_service)
            {
                ErrorInfo = "Restart Service [" + this.m_ServiceName + "] [" + ex_restart_service.Message + "]";
                return false;
            }
        }

        public bool StopService(bool ToDebug,
                 out string ErrorInfo)
        {
            try
            {
               
                System.ServiceProcess.ServiceController Service;
                if (this.m_MachineName != "")
                { Service = new ServiceController(this.m_ServiceName, this.m_MachineName); }
                else
                { Service = new ServiceController(this.m_ServiceName); }

                //stop all the Dependent services...
                foreach (System.ServiceProcess.ServiceController dependent_service
                                in Service.DependentServices)
                {
                    switch (dependent_service.Status)
                    {
                        case ServiceControllerStatus.Stopped:
                            //already stopped...nothing to do
                            break;

                        case ServiceControllerStatus.StopPending:
                            dependent_service.WaitForStatus(ServiceControllerStatus.Stopped);
                            break;

                        default:
                            Service.Stop();
                            Service.WaitForStatus(ServiceControllerStatus.Stopped);
                            break;
                    }
                }

                //stop main service...
                switch (Service.Status)
                {
                    case ServiceControllerStatus.Stopped:
                        //already stopped...nothing to do
                        break;

                    case ServiceControllerStatus.StopPending:
                        Service.WaitForStatus(ServiceControllerStatus.Stopped);
                        break;

                    default:
                        // *-*************************************************************************
                        //check all dependent services?
                        foreach (System.ServiceProcess.ServiceController dependent_service
                                            in Service.DependentServices)
                        {
                            switch (dependent_service.Status)
                            {
                                case ServiceControllerStatus.Stopped:
                                    //already stopped...nothing to do
                                    break;

                                case ServiceControllerStatus.StopPending:
                                    dependent_service.WaitForStatus(ServiceControllerStatus.Stopped);
                                    break;

                                default:
                                    Service.Stop();
                                    Service.WaitForStatus(ServiceControllerStatus.Stopped);
                                    break;
                            }


                        }

                        if (!Service.CanStop)
                        {
                            throw new Exception("Cannot stop service [" +
                                    this.m_ServiceName + "]");
                        }
                        Service.Stop();
                        Service.WaitForStatus(ServiceControllerStatus.Stopped);
                        break;
                }

                Service.Close();

                ErrorInfo = "";
                return true;
            }

            catch (Exception ex_stop_service)
            {
                ErrorInfo = ex_stop_service.Message;
                return false;
            }

        }


        public bool StartService(bool ToDebug,
                    out string ErrorInfo)
        {
            try
            {
              
                System.ServiceProcess.ServiceController Service;
                if (this.m_MachineName != "")
                { Service = new ServiceController(this.m_ServiceName, this.m_MachineName); }
                else
                { Service = new ServiceController(this.m_ServiceName); }

                switch (Service.Status)
                {
                    case ServiceControllerStatus.Stopped:
                        Service.Start();
                        Service.WaitForStatus(ServiceControllerStatus.Running);
                        break;

                    case ServiceControllerStatus.StopPending:
                        //wait for it to stop
                        Service.WaitForStatus(ServiceControllerStatus.Stopped);
                        //... and then start
                        Service.Start();
                        Service.WaitForStatus(ServiceControllerStatus.Running);
                        break;

                    case ServiceControllerStatus.StartPending:
                        //nothing to do...just wait
                        Service.WaitForStatus(ServiceControllerStatus.Running);
                        break;

                    case ServiceControllerStatus.Running:
                        //nothing to do.already running...
                        break;

                    default:
                        Service.Start();
                        Service.WaitForStatus(ServiceControllerStatus.Running);
                        break;
                }

                //start all the Dependent services...
                foreach (System.ServiceProcess.ServiceController dependent_service
                                in Service.DependentServices)
                {

                    switch (dependent_service.Status)
                    {
                        case ServiceControllerStatus.StartPending:
                            //just wait for it to start
                            dependent_service.WaitForStatus(ServiceControllerStatus.Running);
                            break;

                        case ServiceControllerStatus.Running:
                            //already running.nothing to do
                            break;

                        default:
                            NTServiceInfo si =
                                    new NTServiceInfo(dependent_service.ServiceName,
                                            this.m_MachineName);
                            if (!si.StartService(ToDebug, out ErrorInfo))
                            {
                                throw new Exception("Failed to start Dependent Service [" +
                                                dependent_service.ServiceName +
                                                "] - Error [" + ErrorInfo + "]");
                            }
                            break;
                    }
                }

                Service.Close();

                ErrorInfo = "";
                return true;
            }
            catch (Exception ex_start_service)
            {
                ErrorInfo = ex_start_service.Message;
                return false;
            }

        }

        public string ServiceStatus()
        {
            System.ServiceProcess.ServiceController Service;
            if (this.m_MachineName != "")
            { Service = new ServiceController(this.m_ServiceName, this.m_MachineName); }
            else
            { Service = new ServiceController(this.m_ServiceName); }

            return Service.Status.ToString();
        }
    }


}
