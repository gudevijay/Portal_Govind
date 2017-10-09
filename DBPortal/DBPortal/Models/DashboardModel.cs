using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DBPortal.Models
{
    public class DashboardModel
    {
        public CriticalAlerts Critical { get; set; }
        public MySqlAlerts SqlAlerts { get; set; }
        public SyBaseAlerts SybaseAlerts { get; set; }
        public OtherAlerts otherAlerts { get; set; }
    }

    public class CriticalAlerts
    {
        public int MsSql { get; set; }
        public int SyBase { get; set; }
        public int Oracle { get; set; }
        public int MySql { get; set; }
        public int MongoDB { get; set; }
        public int Vertica { get; set; }

    }

    public class MySqlAlerts
    {
        public int Errors { get; set; }
        public int Warnings { get; set; }

    }

    public class SyBaseAlerts
    {
        public int Errors { get; set; }
        public int Warings { get; set; }
    }

    public class OtherAlerts
    {
        public int Errors { get; set; }
        public int Warings { get; set; }
    }

    public class InventoryModel
    {
        public string ServerID { get; set; }
        public string ServerIP { get; set; }
        public int ServerPort { get; set; }
        public string Name { get; set; }
        public string InstanceName { get; set; }
        public string SQLVersion { get; set; }
        public string Edition { get; set; }
        public string OSVesion { get; set; }
        public string ServeType { get; set; }
        public bool IsActive { get; set; }
        public string ServerEnv { get; set; }
        public string Description { get; set; }
        public string CommonName { get; set; }
        public string CMDB_Location { get; set; }
    }

    public class QueryResults
    {
        public string ServerType { get; set; }
        public string ServerName { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string Environment { get; set; }
    }

    public class ServerNames
    {
        public int ServerID { get; set; }
        public string ServerName { get; set; }
    }



}