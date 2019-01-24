using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Comfama.ISAP
{
	public class Employee{
		
		
		string document;
		  string document_type;
		  string document_type_name;
		  string name;
		  string family_name;
		  string last_name;
		  string birthdate;
		  string age;
		  string gender;
		  string gender_name;
		  string marital_status;
		  string marital_status_name;
		  string family_groups;
		  string salary;
		  string salary_type;
		  string salary_type_name;
		  string monthly_hours;
		  string contribution;
		  string type;
		  string type_name;
		  string card_number;
		  string card_status;
		  string card_status_name;
		  string card_status_date;
		  string status;
		  string status_name;
		  string status_date;
		  string status_reason;
		  string status_reason_name;
		  string validity;
		  string validity_name;
		  string category;
		  string category_name;
		  string has_debt;
		  string has_deposit;
		  string has_multienrollment;
		  string retirement_date;
		  string enrollment_date;
		  string unemployment_date;
		  string company_enrollment;
		  string company_document;
		  string company_name;
		  string company_address;
		  string company_phone;
		  string company_town;
		  string company_town_name;
		  string company_zone;
		  string company_zone_name;
		  string company_status;
		  string company_status_name;
		  string company_status_date;
		  string company_status_reason;
		  string company_status_reason_name;
		  string company_contribution_date;
		  string company_contribution_mode;
		  string company_contribution_mode_name;
		  string company_division;
		  string company_branch;
		  string company_job;
		  Companies companies;
		  
		
			public string aDocument{
				get{ return document;}
				set{ document = value; }
			}
		  
			public string aDocument_type{
				get{ return document_type;}
				set{ document_type = value; }
			}
		  
			public string aDocument_type_name{
				get{ return document_type_name;}
				set{ document_type_name = value; }
			}
		  
			public string aName{
				get{ return name;}
				set{ name = value; }
			}
		  
			public string aFamily_name{
				get{ return family_name;}
				set{ family_name = value; }
			}
		  
			public string aLast_name{
				get{ return last_name;}
				set{ last_name = value; }
			}
		  
			public string aBirthdate{
				get{ return birthdate;}
				set{ birthdate = value; }
			}
		  
			public string aAge{
				get{ return age;}
				set{ age = value; }
			}
		  
			public string aGender{
				get{ return gender;}
				set{ gender = value; }
			}
		  
			public string aGender_name{
				get{ return gender_name;}
				set{ gender_name = value; }
			}
		  
			public string aMarital_status{
				get{ return marital_status;}
				set{ marital_status = value; }
			}
		  
			public string aMarital_status_name{
				get{ return marital_status_name;}
				set{ marital_status_name = value; }
			}
		  
			public string aFamily_groups{
				get{ return family_groups;}
				set{ family_groups = value; }
			}
		  
			public string aSalary{
				get{ return salary;}
				set{ salary = value; }
			}
		  
			public string aSalary_type{
				get{ return salary_type;}
				set{ salary_type = value; }
			}
		  
			public string aSalary_type_name{
				get{ return salary_type_name;}
				set{ salary_type_name = value; }
			}
		  
			public string aMonthly_hours{
				get{ return monthly_hours;}
				set{ monthly_hours = value; }
			}
		  
			public string aContribution{
				get{ return contribution;}
				set{ contribution = value; }
			}
		  
			public string aType{
				get{ return type;}
				set{ type = value; }
			}
		  
			public string aType_name{
				get{ return type_name;}
				set{ type_name = value; }
			}
		  
			public string aCard_number{
				get{ return card_number;}
				set{ card_number = value; }
			}
		  
			public string aCard_status{
				get{ return card_status;}
				set{ card_status = value; }
			}
		  
			public string aCard_status_name{
				get{ return card_status_name;}
				set{ card_status_name = value; }
			}
		  
			public string aCard_status_date{
				get{ return card_status_date;}
				set{ card_status_date = value; }
			}
		  
			public string aStatus{
				get{ return status;}
				set{ status = value; }
			}
		  
			public string aStatus_name{
				get{ return status_name;}
				set{ status_name = value; }
			}
		  
			public string aStatus_date{
				get{ return status_date;}
				set{ status_date = value; }
			}
		  
			public string aStatus_reason{
				get{ return status_reason;}
				set{ status_reason = value; }
			}
		  
			public string aStatus_reason_name{
				get{ return status_reason_name;}
				set{ status_reason_name = value; }
			}
		  
			public string aValidity{
				get{ return validity;}
				set{ validity = value; }
			}
		  
			public string aValidity_name{
				get{ return validity_name;}
				set{ validity_name = value; }
			}
		  
			public string aCategory{
				get{ return category;}
				set{ category = value; }
			}
		  
			public string aCategory_name{
				get{ return category_name;}
				set{ category_name = value; }
			}
		  
			public string aHas_debt{
				get{ return has_debt;}
				set{ has_debt = value; }
			}
		  
			public string aHas_deposit{
				get{ return has_deposit;}
				set{ has_deposit = value; }
			}
		  
			public string aHas_multienrollment{
				get{ return has_multienrollment;}
				set{ has_multienrollment = value; }
			}
		  
			public string aRetirement_date{
				get{ return retirement_date;}
				set{ retirement_date = value; }
			}
		  
			public string aEnrollment_date{
				get{ return enrollment_date;}
				set{ enrollment_date = value; }
			}
		  
			public string aUnemployment_date{
				get{ return unemployment_date;}
				set{ unemployment_date = value; }
			}
		  
			public string aCompany_enrollment{
				get{ return company_enrollment;}
				set{ company_enrollment = value; }
			}
		  
			public string aCompany_document{
				get{ return company_document;}
				set{ company_document = value; }
			}
		  
			public string aCompany_name{
				get{ return company_name;}
				set{ company_name = value; }
			}
		  
			public string aCompany_address{
				get{ return company_address;}
				set{ company_address = value; }
			}
		  
			public string aCompany_phone{
				get{ return company_phone;}
				set{ company_phone = value; }
			}
		  
			public string aCompany_town{
				get{ return company_town;}
				set{ company_town = value; }
			}
		  
			public string aCompany_town_name{
				get{ return company_town_name;}
				set{ company_town_name = value; }
			}
		  
			public string aCompany_zone{
				get{ return company_zone;}
				set{ company_zone = value; }
			}
		  
			public string aCompany_zone_name{
				get{ return company_zone_name;}
				set{ company_zone_name = value; }
			}
		  
			public string aCompany_status{
				get{ return company_status;}
				set{ company_status = value; }
			}
		  
			public string aCompany_status_name{
				get{ return company_status_name;}
				set{ company_status_name = value; }
			}
		  
			public string aCompany_status_date{
				get{ return company_status_date;}
				set{ company_status_date = value; }
			}
		  
			public string aCompany_status_reason{
				get{ return company_status_reason;}
				set{ company_status_reason = value; }
			}
		  
			public string aCompany_status_reason_name{
				get{ return company_status_reason_name;}
				set{ company_status_reason_name = value; }
			}
		  
			public string aCompany_contribution_date{
				get{ return company_contribution_date;}
				set{ company_contribution_date = value; }
			}
		  
			public string aCompany_contribution_mode{
				get{ return company_contribution_mode;}
				set{ company_contribution_mode = value; }
			}
		  
			public string aCompany_contribution_mode_name{
				get{ return company_contribution_mode_name;}
				set{ company_contribution_mode_name = value; }
			}
		  
			public string aCompany_division{
				get{ return company_division;}
				set{ company_division = value; }
			}
		  
			public string aCompany_branch{
				get{ return company_branch;}
				set{ company_branch = value; }
			}
		  
			public string aCompany_job{
				get{ return company_job;}
				set{ company_job = value; }
			}
		  
			public Companies aCompanies{
				get{ return companies;}
				set{ companies = value; }
			}
		  
			
		public static Employee obtenerDesdeDataSet(DataSet ds)
        {
            Employee obj = new Employee();
            DataTable dt;
            if (ds.Tables.Count > 0)
            {
                dt = ds.Tables[""];
                if (dt != null)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        obj.document = dt.Columns.Contains("document") == true ? dr["document"].ToString() : null;
						  obj.document_type = dt.Columns.Contains("document_type") == true ? dr["document_type"].ToString() : null;
						  obj.document_type_name = dt.Columns.Contains("document_type_name") == true ? dr["document_type_name"].ToString() : null;
						  obj.name = dt.Columns.Contains("name") == true ? dr["name"].ToString() : null;
						  obj.family_name = dt.Columns.Contains("family_name") == true ? dr["family_name"].ToString() : null;
						  obj.last_name = dt.Columns.Contains("last_name") == true ? dr["last_name"].ToString() : null;
						  obj.birthdate = dt.Columns.Contains("birthdate") == true ? dr["birthdate"].ToString() : null;
						  obj.age = dt.Columns.Contains("age") == true ? dr["age"].ToString() : null;
						  obj.gender = dt.Columns.Contains("gender") == true ? dr["gender"].ToString() : null;
						  obj.gender_name = dt.Columns.Contains("gender_name") == true ? dr["gender_name"].ToString() : null;
						  obj.marital_status = dt.Columns.Contains("marital_status") == true ? dr["marital_status"].ToString() : null;
						  obj.marital_status_name = dt.Columns.Contains("marital_status_name") == true ? dr["marital_status_name"].ToString() : null;
						  obj.family_groups = dt.Columns.Contains("family_groups") == true ? dr["family_groups"].ToString() : null;
						  obj.salary = dt.Columns.Contains("salary") == true ? dr["salary"].ToString() : null;
						  obj.salary_type = dt.Columns.Contains("salary_type") == true ? dr["salary_type"].ToString() : null;
						  obj.salary_type_name = dt.Columns.Contains("salary_type_name") == true ? dr["salary_type_name"].ToString() : null;
						  obj.monthly_hours = dt.Columns.Contains("monthly_hours") == true ? dr["monthly_hours"].ToString() : null;
						  obj.contribution = dt.Columns.Contains("contribution") == true ? dr["contribution"].ToString() : null;
						  obj.type = dt.Columns.Contains("type") == true ? dr["type"].ToString() : null;
						  obj.type_name = dt.Columns.Contains("type_name") == true ? dr["type_name"].ToString() : null;
						  obj.card_number = dt.Columns.Contains("card_number") == true ? dr["card_number"].ToString() : null;
						  obj.card_status = dt.Columns.Contains("card_status") == true ? dr["card_status"].ToString() : null;
						  obj.card_status_name = dt.Columns.Contains("card_status_name") == true ? dr["card_status_name"].ToString() : null;
						  obj.card_status_date = dt.Columns.Contains("card_status_date") == true ? dr["card_status_date"].ToString() : null;
						  obj.status = dt.Columns.Contains("status") == true ? dr["status"].ToString() : null;
						  obj.status_name = dt.Columns.Contains("status_name") == true ? dr["status_name"].ToString() : null;
						  obj.status_date = dt.Columns.Contains("status_date") == true ? dr["status_date"].ToString() : null;
						  obj.status_reason = dt.Columns.Contains("status_reason") == true ? dr["status_reason"].ToString() : null;
						  obj.status_reason_name = dt.Columns.Contains("status_reason_name") == true ? dr["status_reason_name"].ToString() : null;
						  obj.validity = dt.Columns.Contains("validity") == true ? dr["validity"].ToString() : null;
						  obj.validity_name = dt.Columns.Contains("validity_name") == true ? dr["validity_name"].ToString() : null;
						  obj.category = dt.Columns.Contains("category") == true ? dr["category"].ToString() : null;
						  obj.category_name = dt.Columns.Contains("category_name") == true ? dr["category_name"].ToString() : null;
						  obj.has_debt = dt.Columns.Contains("has_debt") == true ? dr["has_debt"].ToString() : null;
						  obj.has_deposit = dt.Columns.Contains("has_deposit") == true ? dr["has_deposit"].ToString() : null;
						  obj.has_multienrollment = dt.Columns.Contains("has_multienrollment") == true ? dr["has_multienrollment"].ToString() : null;
						  obj.retirement_date = dt.Columns.Contains("retirement_date") == true ? dr["retirement_date"].ToString() : null;
						  obj.enrollment_date = dt.Columns.Contains("enrollment_date") == true ? dr["enrollment_date"].ToString() : null;
						  obj.unemployment_date = dt.Columns.Contains("unemployment_date") == true ? dr["unemployment_date"].ToString() : null;
						  obj.company_enrollment = dt.Columns.Contains("company_enrollment") == true ? dr["company_enrollment"].ToString() : null;
						  obj.company_document = dt.Columns.Contains("company_document") == true ? dr["company_document"].ToString() : null;
						  obj.company_name = dt.Columns.Contains("company_name") == true ? dr["company_name"].ToString() : null;
						  obj.company_address = dt.Columns.Contains("company_address") == true ? dr["company_address"].ToString() : null;
						  obj.company_phone = dt.Columns.Contains("company_phone") == true ? dr["company_phone"].ToString() : null;
						  obj.company_town = dt.Columns.Contains("company_town") == true ? dr["company_town"].ToString() : null;
						  obj.company_town_name = dt.Columns.Contains("company_town_name") == true ? dr["company_town_name"].ToString() : null;
						  obj.company_zone = dt.Columns.Contains("company_zone") == true ? dr["company_zone"].ToString() : null;
						  obj.company_zone_name = dt.Columns.Contains("company_zone_name") == true ? dr["company_zone_name"].ToString() : null;
						  obj.company_status = dt.Columns.Contains("company_status") == true ? dr["company_status"].ToString() : null;
						  obj.company_status_name = dt.Columns.Contains("company_status_name") == true ? dr["company_status_name"].ToString() : null;
						  obj.company_status_date = dt.Columns.Contains("company_status_date") == true ? dr["company_status_date"].ToString() : null;
						  obj.company_status_reason = dt.Columns.Contains("company_status_reason") == true ? dr["company_status_reason"].ToString() : null;
						  obj.company_status_reason_name = dt.Columns.Contains("company_status_reason_name") == true ? dr["company_status_reason_name"].ToString() : null;
						  obj.company_contribution_date = dt.Columns.Contains("company_contribution_date") == true ? dr["company_contribution_date"].ToString() : null;
						  obj.company_contribution_mode = dt.Columns.Contains("company_contribution_mode") == true ? dr["company_contribution_mode"].ToString() : null;
						  obj.company_contribution_mode_name = dt.Columns.Contains("company_contribution_mode_name") == true ? dr["company_contribution_mode_name"].ToString() : null;
						  obj.company_division = dt.Columns.Contains("company_division") == true ? dr["company_division"].ToString() : null;
						  obj.company_branch = dt.Columns.Contains("company_branch") == true ? dr["company_branch"].ToString() : null;
						  obj.company_job = dt.Columns.Contains("company_job") == true ? dr["company_job"].ToString() : null;
						  obj.companies = dt.Columns.Contains("companies") == true ? dr["companies"].ToString() : null;
						  
                    }
                }
            }
            return obj;
        }
	}
}