using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ZCRMSDK.CRM.Library.Api.Response;
using ZCRMSDK.CRM.Library.Common;
using ZCRMSDK.CRM.Library.CRUD;

namespace ZohoCRMWebApp.Models
{
    public class ZohoCRMRequests
    {
        public static IList GetRecords(string module_name, long module_id, List<string> fields)
        {        
            ZCRMModule moduleIns = ZCRMModule.GetInstance(module_name);
            string modifiedTime = DateTime.Today.ToString("yyyy-MM-dd'T'HH:mm:ss");
            BulkAPIResponse<ZCRMRecord> response = moduleIns.GetRecords(module_id, "id", CommonUtil.SortOrder.asc, 1, 200, modifiedTime, fields);          
            return response.ResponseJSON;
        }
        public static IList GetRecordById(string module_name, long record_id)
        {
            ZCRMModule moduleIns = ZCRMModule.GetInstance(module_name); 
            APIResponse response = moduleIns.GetRecord(record_id);         
            return response.ResponseJSON;
        }
        public static IList CreateRecord(string module_name, string mandatory_name, Dictionary<string, string> createMap) 
        {
            List<ZCRMRecord> listRecord = new List<ZCRMRecord>();
            ZCRMRecord record = new ZCRMRecord(module_name);
            foreach (var el in createMap)
            {
                record.SetFieldValue(el.Key, el.Value);
                if (module_name == "Leads")
                {
                    record.SetFieldValue("Last_Name", mandatory_name);
                }
                if (module_name == "Contacts")
                {
                    record.SetFieldValue("Last_Name", mandatory_name);
                }
                if (module_name == "Accounts")
                {
                    record.SetFieldValue("Account_Name", mandatory_name);
                }
            }
            listRecord.Add(record);
            ZCRMModule moduleIns = ZCRMModule.GetInstance(module_name);
            BulkAPIResponse<ZCRMRecord> response = moduleIns.CreateRecords(listRecord);
            return response.ResponseJSON;
        }

        public static IList UpdateRecord(string module_name, long record_id, Dictionary<string, string> updateMap) 
        {
            List<ZCRMRecord> listRecord = new List<ZCRMRecord>();  
            ZCRMRecord record = new ZCRMRecord(module_name);
            record.SetFieldValue("id", record_id);
            foreach (var el in updateMap)
            {
                record.SetFieldValue(el.Key, el.Value);             
            }
            listRecord.Add(record);
            ZCRMModule moduleIns = ZCRMModule.GetInstance(module_name); 
            BulkAPIResponse<ZCRMRecord> response = moduleIns.UpdateRecords(listRecord); 
            return response.ResponseJSON;
        }
    }
}
