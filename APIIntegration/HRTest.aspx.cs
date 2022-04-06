using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using APIIntegration.CONNECT;

namespace APIIntegration
{
    public partial class HRTest : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["jcfEntities"].ConnectionString);
            string command = "SELECT * FROM JCFPersonnelforPilot";
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter(command, con);
            DataSet dt = new DataSet();
            sda.Fill(dt);
            foreach (DataRow row in dt.Tables[0].Rows)
            {
                HumanResourcesInboundServiceSoapClient humanResources = new HumanResourcesInboundServiceSoapClient();
                savePersonnelRequest save = new savePersonnelRequest();
                savePersonnelResponse response = new savePersonnelResponse();
                save.personnelRecords = new PersonnelRecord[]
                {
                    new PersonnelRecord
                    {
                        recordStatus = row["recordStatus"].ToString() == "New" ? RecordOperationEnum.New : row["recordStatus"].ToString() == "Amend" ? RecordOperationEnum.Amend : RecordOperationEnum.Archive,
                        forceID = new ConstrainedValue
                        {
                            cvCode = row["forceID"].ToString(),
                            description = row["forceDescription"].ToString()
                        },
                        personnelID = row["personnelId"].ToString() == null?"": row["personnelId"].ToString(),
                        uniqueNationalIdentifier = row["uniqueNationalIdentifier"].ToString() == null?"": row["uniqueNationalIdentifier"].ToString(),
                        collarNumber = row["collarNumber"].ToString() == null?"": row["collarNumber"].ToString(),
                        pncUserID = row["pncUserID"].ToString() == null?"": row["pncUserID"].ToString(),
                        title = new ConstrainedValue
                        {
                            cvCode = row["title"].ToString(),
                            description = row["titleDescription"].ToString()
                        },
                        surname = row["surname"].ToString() == null?"": row["surname"].ToString(),
                        forename1 = row["forename1"].ToString() == null?"":row["forename1"].ToString(),
                        forename2 = row["forename2"].ToString() == null?"":row["forename2"].ToString(),
                        forename3 = "",
                        gender = new ConstrainedValue
                        {
                            cvCode = row["gender"].ToString(),
                            description = row["genderDescription"].ToString()
                        },
                        supervisor = new supervisor
                        {
                            fullName = "",
                            forceID = new ConstrainedValue
                            {
                                cvCode = row["forceID"].ToString(),
                                description = row["forceDescription"].ToString()
                            },
                            personnelID = "",
                            uniqueNationalIdentifier = ""
                        },
                        stationName = row["stationName"].ToString() == null?"":row["stationName"].ToString(),
                        stationCode = "",
                        emailAddress = row["EmailAddress"].ToString() == null?"":row["EmailAddress"].ToString(),
                        employmentHistory = new EmploymentRecord[]
                        {
                            new EmploymentRecord
                            {
                                from = (DateTime)row["from"] == null?DateTime.MinValue:(DateTime)row["from"],
                                to = (DateTime)row["to"] == null?DateTime.MinValue:(DateTime)row["to"],
                                rank = new ConstrainedValue
                                {
                                    cvCode = row["rank"].ToString() == null?"":row["rank"].ToString(),
                                    description = row["rankDescription"].ToString() == null?"":row["rankDescription"].ToString()
                                }
                            }
                        },
                        defaultUnit = new ConstrainedValue
                        {
                            cvCode = row["defaultUnit"].ToString() == null?"":row["defaultUnit"].ToString(),
                            description = ""
                        },
                        defaultSubmitUnit = new ConstrainedValue
                        {
                            cvCode = row["defaultSubmitUnit"].ToString() == null?"":row["defaultSubmitUnit"].ToString(),
                            description = ""
                        },
                        currentUnits = new UnitRole[]
                        {
                            new UnitRole
                            {
                                unit = new ConstrainedValue
                                {
                                    cvCode = row["currentUnit"].ToString() == null?"":row["currentUnit"].ToString(),
                                    description = ""
                                },
                                role = new ConstrainedValue
                                {
                                    cvCode = row["currentUnitRole"].ToString() == null?"":row["currentUnitRole"].ToString(),
                                    description = ""
                                }
                            }
                        }
                    }
                };


                string certName = @"C:\Users\shevon.robinson\source\repos\APIIntegration\API INFO\client-cert1.pfx";
                string password = @"$tXudQfm1CIJ";

                //Bind a client certificate to the web request being sent
                X509Certificate2Collection certificates = new X509Certificate2Collection();
                certificates.Import(certName, password, X509KeyStorageFlags.MachineKeySet | X509KeyStorageFlags.PersistKeySet);

                ServicePointManager.Expect100Continue = true;
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;


                //response.savePersonnelResult = 
                    humanResources.savePersonnel(save.personnelRecords, ref save.extension, out response.saveStatusList);
                lblResult.Text = response.savePersonnelResult.ToString();
            }
        }
        protected void btnadd_Click(object sender, EventArgs e)
        {
                  
        }
    }
}