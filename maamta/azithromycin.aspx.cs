using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace maamta
{
    public partial class azithromycin : System.Web.UI.Page
    {
        string constr = ConfigurationManager.ConnectionStrings["LocalMySql"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GraphColor();
                ShowGraph();
                Session["WebForm"] = "AzithromycinTask";
            }
        }




        protected void btnGraph_Click(object sender, EventArgs e)
        {
            GraphColor();
            ShowGraph();
        }

        protected void btnPending_Click(object sender, EventArgs e)
        {
            pendingColor();
            ShowDataPending();
            txtdssidPending.Focus();
        }

        protected void btnDose_Click(object sender, EventArgs e)
        {
            doseColor();
            ShowDataDose();
            txtdssidDose.Focus();
        }

        private void GraphColor()
        {
            btnGraph.Style.Add("color", "white");
            btnGraph.Style.Add("background-color", "#55efc4");

            btnPending.Style.Add("color", "#adadad");
            btnPending.Style.Add("background-color", "#e0e0e0");
            btnDose.Style.Add("color", "#adadad");
            btnDose.Style.Add("background-color", "#e0e0e0");

            divGraph.Visible = true;
            divDose.Visible = false;
            divPending.Visible = false;
        }

        private void pendingColor()
        {
            btnPending.Style.Add("color", "white");
            btnPending.Style.Add("background-color", "#55efc4");

            btnDose.Style.Add("color", "#adadad");
            btnDose.Style.Add("background-color", "#e0e0e0");
            btnGraph.Style.Add("color", "#adadad");
            btnGraph.Style.Add("background-color", "#e0e0e0");

            divPending.Visible = true;
            divDose.Visible = false;
            divGraph.Visible = false;
        }

        private void doseColor()
        {
            btnDose.Style.Add("color", "white");
            btnDose.Style.Add("background-color", "#55efc4");

            btnPending.Style.Add("color", "#adadad");
            btnPending.Style.Add("background-color", "#e0e0e0");
            btnGraph.Style.Add("color", "#adadad");
            btnGraph.Style.Add("background-color", "#e0e0e0");

            divDose.Visible = true;
            divPending.Visible = false;
            divGraph.Visible = false;
        }









        private void ShowGraph()
        {
            LoadChartSiteWise();
            LoadChartAllSite();
            LoadChartDoseDayWise();
        }


        private void LoadChartSiteWise()
        {
            Chart1.ChartAreas["ChartArea1"].AxisX.MajorGrid.Enabled = false;
            Chart1.DataBindCrossTable(GetDataItem().DefaultView, "site", "Eligible, Cumulative", "total", "Label=total");
            Chart1.DataBind();
        }


        private DataTable GetDataItem()
        {
            MySqlConnection con = new MySqlConnection(constr);
            con.Open();
            MySqlCommand cmd = new MySqlCommand("select site.site,'Eligible, Cumulative', Table_A.total from site 		left join  (select site,count(*) as total from view_vaccination where arm ='c' and current_age >= 42 group by site) as Table_A  on Table_A.site=site.site  	 union all select site.site,'Dose Received, Cumulative',Table_A.total from site 		left join   (select site,count(*) as total  from (select c.lw_crf_1_11 as site,a.study_code from form_crf_5a as z  left join studies as a on a.study_id=z.study_id 	left join pw as b on b.id=a.assis_id left join dss_address as c on c.dss_id=b.dss_id left join form_crf_2 as d on a.assis_id=d.assis_id    where  z.form_crf_5a_id in (select zz.form_crf_5a_id from form_crf_5a as zz where zz.study_id=z.study_id and  (zz.lw_crf5a_53=1 || zz.lw_crf5a_53=2)) group by a.study_code) as UUU group by UUU.site) as Table_A   on Table_A.site=site.site  	 union all select site.site,'Dose Received less than 42 days',Table_A.total from site 		left join   (select site,count(*) as total  from (select z.form_crf_5a_id,z.followup_num,z.lw_crf5a_02,d.lw_crf2_21 as dob,z.study_id,a.study_code,DATEDIFF(str_to_date(z.lw_crf5a_02, '%d-%m-%Y'),str_to_date(d.lw_crf2_21 , '%d-%m-%Y')) as age,c.lw_crf_1_11 as site from form_crf_5a as z  left join studies as a on a.study_id=z.study_id 	left join pw as b on b.id=a.assis_id left join dss_address as c on c.dss_id=b.dss_id left join form_crf_2 as d on a.assis_id=d.assis_id    where  z.form_crf_5a_id in (select zz.form_crf_5a_id from form_crf_5a as zz where zz.study_id=z.study_id and  (zz.lw_crf5a_53=1 || zz.lw_crf5a_53=2)) group by a.study_code) as zzzz where age<42 group by zzzz.site) as Table_A  on Table_A.site=site.site 	   	 union all select site.site,'Dose Received Age between 42 to 44 days',Table_A.total from site 		left join   (select site,count(*) as total  from (select z.form_crf_5a_id,z.followup_num,z.lw_crf5a_02,d.lw_crf2_21 as dob,z.study_id,a.study_code,DATEDIFF(str_to_date(z.lw_crf5a_02, '%d-%m-%Y'),str_to_date(d.lw_crf2_21 , '%d-%m-%Y')) as age,c.lw_crf_1_11 as site from form_crf_5a as z  left join studies as a on a.study_id=z.study_id 	left join pw as b on b.id=a.assis_id left join dss_address as c on c.dss_id=b.dss_id left join form_crf_2 as d on a.assis_id=d.assis_id    where  z.form_crf_5a_id in (select zz.form_crf_5a_id from form_crf_5a as zz where zz.study_id=z.study_id and  (zz.lw_crf5a_53=1 || zz.lw_crf5a_53=2)) group by a.study_code) as zzzz where age>=42  and age<=44  group by zzzz.site) as Table_A  on Table_A.site=site.site  	 union all select site.site,'Dose Received Age greater than 44 days',Table_A.total from site 		left join   (select site,count(*) as total  from (select z.form_crf_5a_id,z.followup_num,z.lw_crf5a_02,d.lw_crf2_21 as dob,z.study_id,a.study_code,DATEDIFF(str_to_date(z.lw_crf5a_02, '%d-%m-%Y'),str_to_date(d.lw_crf2_21 , '%d-%m-%Y')) as age,c.lw_crf_1_11 as site from form_crf_5a as z  left join studies as a on a.study_id=z.study_id 	left join pw as b on b.id=a.assis_id left join dss_address as c on c.dss_id=b.dss_id left join form_crf_2 as d on a.assis_id=d.assis_id    where  z.form_crf_5a_id in (select zz.form_crf_5a_id from form_crf_5a as zz where zz.study_id=z.study_id and  (zz.lw_crf5a_53=1 || zz.lw_crf5a_53=2)) group by a.study_code) as zzzz where age>44  group by zzzz.site) as Table_A  on Table_A.site=site.site  	 union all select site.site,'Dose Pending (Cumulative), Age greater than 42 days', Table_A.total from site 		left join   (select site,count(*) as total  from   (select i.lw_crf_3a_4 as study_id,l.lw_crf_1_11 as site,i.lw_crf_3a_18 as random_id, j.lw_crf2_21 as dob,DATE_FORMAT(AddDate((str_to_date(j.lw_crf2_21, '%d-%m-%Y')), interval 42 DAY),'%d-%m-%Y') as  Age_Day_42,  DATEDIFF(CURDATE(),str_to_date(j.lw_crf2_21, '%d-%m-%Y')) as current_age, j.date_of_attempt as enrollment,k.lw_crf1_09 as woman_nm, k.lw_crf1_10 as husband_nm, concat(l.lw_crf_1_11,l.lw_crf_1_12,l.lw_crf_1_13,l.lw_crf_1_14,l.lw_crf_1_15,l.lw_crf_1_16) as dssid, (select zz.lw_crf4a_24 from form_crf_4a as zz  where zz.lw_crf4a_23=2 and m.study_id=zz.study_id) as DOD from form_crf_3a as i left join form_crf_2 as j on i.assis_id=j.assis_id left join pw as k on k.id=i.assis_id left join dss_address l on k.dss_id=l.dss_id   left join studies as m on m.assis_id=k.id where DATEDIFF(CURDATE(),str_to_date(j.lw_crf2_21, '%d-%m-%Y')) >42		and i.lw_crf_3a_19='c' and  not exists (select a.form_crf_5a_id,a.followup_num,a.study_id from form_crf_5a as a where  m.study_id=a.study_id and a.form_crf_5a_id=(SELECT max(z.form_crf_5a_id) from form_crf_5a as z where a.study_id=z.study_id and (z.lw_crf5a_53='1' || z.lw_crf5a_53='2')) group by a.study_id)) as zzzz group by zzzz.site)  as Table_A   on Table_A.site=site.site  	 union all select site.site,'Dose Pending (Refusal), Age greater than 42 days', Table_A.total from site 		left join   (select site,count(*) as total  from    (select i.lw_crf_3a_4 as study_id,l.lw_crf_1_11 as site,i.lw_crf_3a_18 as random_id, j.lw_crf2_21 as dob,DATE_FORMAT(AddDate((str_to_date(j.lw_crf2_21, '%d-%m-%Y')), interval 42 DAY),'%d-%m-%Y') as  Age_Day_42,  DATEDIFF(CURDATE(),str_to_date(j.lw_crf2_21, '%d-%m-%Y')) as current_age, j.date_of_attempt as enrollment,k.lw_crf1_09 as woman_nm, k.lw_crf1_10 as husband_nm, concat(l.lw_crf_1_11,l.lw_crf_1_12,l.lw_crf_1_13,l.lw_crf_1_14,l.lw_crf_1_15,l.lw_crf_1_16) as dssid, (select zz.lw_crf4a_24 from form_crf_4a as zz  where zz.lw_crf4a_23=2 and m.study_id=zz.study_id) as DOD from form_crf_3a as i left join form_crf_2 as j on i.assis_id=j.assis_id left join pw as k on k.id=i.assis_id left join dss_address l on k.dss_id=l.dss_id   left join studies as m on m.assis_id=k.id where DATEDIFF(CURDATE(),str_to_date(j.lw_crf2_21, '%d-%m-%Y')) >=42	 		and i.lw_crf_3a_19='c' and  not exists (select a.form_crf_5a_id,a.followup_num,a.study_id from form_crf_5a as a where  m.study_id=a.study_id and a.form_crf_5a_id=(SELECT max(z.form_crf_5a_id) from form_crf_5a as z where a.study_id=z.study_id and (z.lw_crf5a_53='1' || z.lw_crf5a_53='2')) group by a.study_id)) as zzzz where zzzz.current_age >42 and (zzzz.DOD='' or zzzz.DOD is null)       group by zzzz.site)  as Table_A   on Table_A.site=site.site  	 union all select site.site,'Dose Pending, due to Child Death', Table_A.total from site 		left join   (select site,count(*) as total  from      (select i.lw_crf_3a_4 as study_id,l.lw_crf_1_11 as site,i.lw_crf_3a_18 as random_id, j.lw_crf2_21 as dob,DATE_FORMAT(AddDate((str_to_date(j.lw_crf2_21, '%d-%m-%Y')), interval 42 DAY),'%d-%m-%Y') as  Age_Day_42,  DATEDIFF(CURDATE(),str_to_date(j.lw_crf2_21, '%d-%m-%Y')) as current_age, j.date_of_attempt as enrollment,k.lw_crf1_09 as woman_nm, k.lw_crf1_10 as husband_nm, concat(l.lw_crf_1_11,l.lw_crf_1_12,l.lw_crf_1_13,l.lw_crf_1_14,l.lw_crf_1_15,l.lw_crf_1_16) as dssid, (select zz.lw_crf4a_24 from form_crf_4a as zz  where zz.lw_crf4a_23=2 and m.study_id=zz.study_id) as DOD from form_crf_3a as i left join form_crf_2 as j on i.assis_id=j.assis_id left join pw as k on k.id=i.assis_id left join dss_address l on k.dss_id=l.dss_id   left join studies as m on m.assis_id=k.id where DATEDIFF(CURDATE(),str_to_date(j.lw_crf2_21, '%d-%m-%Y')) >=42				and i.lw_crf_3a_19='c' and  not exists (select a.form_crf_5a_id,a.followup_num,a.study_id from form_crf_5a as a where  m.study_id=a.study_id and a.form_crf_5a_id=(SELECT max(z.form_crf_5a_id) from form_crf_5a as z where a.study_id=z.study_id and (z.lw_crf5a_53='1' || z.lw_crf5a_53='2')) group by a.study_id)) as zzzz where zzzz.DOD!=''      group by zzzz.site)  as Table_A   on Table_A.site=site.site", con);

            //MySqlCommand cmd = new MySqlCommand("select site,'Dose Received, Cumulative',count(*) as total from (select z.form_crf_5a_id,z.followup_num,z.lw_crf5a_02,d.lw_crf2_21 as dob,z.study_id,a.study_code,DATEDIFF(str_to_date(z.lw_crf5a_02, '%d-%m-%Y'),str_to_date(d.lw_crf2_21 , '%d-%m-%Y')) as age,c.lw_crf_1_11 as site from form_crf_5a as z  left join studies as a on a.study_id=z.study_id 	left join pw as b on b.id=a.assis_id left join dss_address as c on c.dss_id=b.dss_id left join form_crf_2 as d on a.assis_id=d.assis_id    where  z.form_crf_5a_id in (select zz.form_crf_5a_id from form_crf_5a as zz where zz.study_id=z.study_id and  (zz.lw_crf5a_53=1 || zz.lw_crf5a_53=2)) group by a.study_code) as Table_A group by Table_A.site  union all select site,'Dose Received less and equal than 42 days',count(*) as total from (select z.form_crf_5a_id,z.followup_num,z.lw_crf5a_02,d.lw_crf2_21 as dob,z.study_id,a.study_code,DATEDIFF(str_to_date(z.lw_crf5a_02, '%d-%m-%Y'),str_to_date(d.lw_crf2_21 , '%d-%m-%Y')) as age,c.lw_crf_1_11 as site from form_crf_5a as z  left join studies as a on a.study_id=z.study_id 	left join pw as b on b.id=a.assis_id left join dss_address as c on c.dss_id=b.dss_id left join form_crf_2 as d on a.assis_id=d.assis_id    where  z.form_crf_5a_id in (select zz.form_crf_5a_id from form_crf_5a as zz where zz.study_id=z.study_id and  (zz.lw_crf5a_53=1 || zz.lw_crf5a_53=2)) group by a.study_code) as Table_A where age<=42  group by Table_A.site  union all select site,'Dose Received greater than 42 days',count(*) as total from (select z.form_crf_5a_id,z.followup_num,z.lw_crf5a_02,d.lw_crf2_21 as dob,z.study_id,a.study_code,DATEDIFF(str_to_date(z.lw_crf5a_02, '%d-%m-%Y'),str_to_date(d.lw_crf2_21 , '%d-%m-%Y')) as age,c.lw_crf_1_11 as site from form_crf_5a as z  left join studies as a on a.study_id=z.study_id 	left join pw as b on b.id=a.assis_id left join dss_address as c on c.dss_id=b.dss_id left join form_crf_2 as d on a.assis_id=d.assis_id    where  z.form_crf_5a_id in (select zz.form_crf_5a_id from form_crf_5a as zz where zz.study_id=z.study_id and  (zz.lw_crf5a_53=1 || zz.lw_crf5a_53=2)) group by a.study_code) as Table_A where age>42  group by Table_A.site  union all select site,'Dose Pending, Cumulative (Age greater than 38 days)',count(*) as total from   (select i.lw_crf_3a_4 as study_id,l.lw_crf_1_11 as site,i.lw_crf_3a_18 as random_id, j.lw_crf2_21 as dob,DATE_FORMAT(AddDate((str_to_date(j.lw_crf2_21, '%d-%m-%Y')), interval 42 DAY),'%d-%m-%Y') as  Age_Day_42,  DATEDIFF(CURDATE(),str_to_date(j.lw_crf2_21, '%d-%m-%Y')) as current_age, j.date_of_attempt as enrollment,k.lw_crf1_09 as woman_nm, k.lw_crf1_10 as husband_nm, concat(l.lw_crf_1_11,l.lw_crf_1_12,l.lw_crf_1_13,l.lw_crf_1_14,l.lw_crf_1_15,l.lw_crf_1_16) as dssid, (select zz.lw_crf4a_24 from form_crf_4a as zz  where zz.lw_crf4a_23=2 and m.study_id=zz.study_id) as DOD from form_crf_3a as i left join form_crf_2 as j on i.assis_id=j.assis_id left join pw as k on k.id=i.assis_id left join dss_address l on k.dss_id=l.dss_id   left join studies as m on m.assis_id=k.id where DATEDIFF(CURDATE(),str_to_date(j.lw_crf2_21, '%d-%m-%Y')) >38 and i.lw_crf_3a_19='c' and  not exists (select a.form_crf_5a_id,a.followup_num,a.study_id from form_crf_5a as a where  m.study_id=a.study_id and a.form_crf_5a_id=(SELECT max(z.form_crf_5a_id) from form_crf_5a as z where a.study_id=z.study_id and (z.lw_crf5a_53='1' || z.lw_crf5a_53='2')) group by a.study_id)) as Table_A group by Table_A.site  union all select site,'Dose Pending, Age greater than 40 days',count(*) as total from   (select i.lw_crf_3a_4 as study_id,l.lw_crf_1_11 as site,i.lw_crf_3a_18 as random_id, j.lw_crf2_21 as dob,DATE_FORMAT(AddDate((str_to_date(j.lw_crf2_21, '%d-%m-%Y')), interval 42 DAY),'%d-%m-%Y') as  Age_Day_42,  DATEDIFF(CURDATE(),str_to_date(j.lw_crf2_21, '%d-%m-%Y')) as current_age, j.date_of_attempt as enrollment,k.lw_crf1_09 as woman_nm, k.lw_crf1_10 as husband_nm, concat(l.lw_crf_1_11,l.lw_crf_1_12,l.lw_crf_1_13,l.lw_crf_1_14,l.lw_crf_1_15,l.lw_crf_1_16) as dssid, (select zz.lw_crf4a_24 from form_crf_4a as zz  where zz.lw_crf4a_23=2 and m.study_id=zz.study_id) as DOD from form_crf_3a as i left join form_crf_2 as j on i.assis_id=j.assis_id left join pw as k on k.id=i.assis_id left join dss_address l on k.dss_id=l.dss_id   left join studies as m on m.assis_id=k.id where DATEDIFF(CURDATE(),str_to_date(j.lw_crf2_21, '%d-%m-%Y')) >38 and i.lw_crf_3a_19='c' and  not exists (select a.form_crf_5a_id,a.followup_num,a.study_id from form_crf_5a as a where  m.study_id=a.study_id and a.form_crf_5a_id=(SELECT max(z.form_crf_5a_id) from form_crf_5a as z where a.study_id=z.study_id and (z.lw_crf5a_53='1' || z.lw_crf5a_53='2')) group by a.study_id)) as Table_A where Table_A.current_age >40 and (Table_A.DOD='' or Table_A.DOD is null) group by Table_A.site  union all select site,'Dose Pending, Age less and Equal than 40 days',count(*) as total from   (select i.lw_crf_3a_4 as study_id,l.lw_crf_1_11 as site,i.lw_crf_3a_18 as random_id, j.lw_crf2_21 as dob,DATE_FORMAT(AddDate((str_to_date(j.lw_crf2_21, '%d-%m-%Y')), interval 42 DAY),'%d-%m-%Y') as  Age_Day_42,  DATEDIFF(CURDATE(),str_to_date(j.lw_crf2_21, '%d-%m-%Y')) as current_age, j.date_of_attempt as enrollment,k.lw_crf1_09 as woman_nm, k.lw_crf1_10 as husband_nm, concat(l.lw_crf_1_11,l.lw_crf_1_12,l.lw_crf_1_13,l.lw_crf_1_14,l.lw_crf_1_15,l.lw_crf_1_16) as dssid, (select zz.lw_crf4a_24 from form_crf_4a as zz  where zz.lw_crf4a_23=2 and m.study_id=zz.study_id) as DOD from form_crf_3a as i left join form_crf_2 as j on i.assis_id=j.assis_id left join pw as k on k.id=i.assis_id left join dss_address l on k.dss_id=l.dss_id   left join studies as m on m.assis_id=k.id where DATEDIFF(CURDATE(),str_to_date(j.lw_crf2_21, '%d-%m-%Y')) >38 and i.lw_crf_3a_19='c' and  not exists (select a.form_crf_5a_id,a.followup_num,a.study_id from form_crf_5a as a where  m.study_id=a.study_id and a.form_crf_5a_id=(SELECT max(z.form_crf_5a_id) from form_crf_5a as z where a.study_id=z.study_id and (z.lw_crf5a_53='1' || z.lw_crf5a_53='2')) group by a.study_id)) as Table_A where Table_A.current_age <=40 and (Table_A.DOD='' or Table_A.DOD is null) group by Table_A.site  union all select site,'Dose Pending, due to Child Death',count(*) as total from   (select i.lw_crf_3a_4 as study_id,l.lw_crf_1_11 as site,i.lw_crf_3a_18 as random_id, j.lw_crf2_21 as dob,DATE_FORMAT(AddDate((str_to_date(j.lw_crf2_21, '%d-%m-%Y')), interval 42 DAY),'%d-%m-%Y') as  Age_Day_42,  DATEDIFF(CURDATE(),str_to_date(j.lw_crf2_21, '%d-%m-%Y')) as current_age, j.date_of_attempt as enrollment,k.lw_crf1_09 as woman_nm, k.lw_crf1_10 as husband_nm, concat(l.lw_crf_1_11,l.lw_crf_1_12,l.lw_crf_1_13,l.lw_crf_1_14,l.lw_crf_1_15,l.lw_crf_1_16) as dssid, (select zz.lw_crf4a_24 from form_crf_4a as zz  where zz.lw_crf4a_23=2 and m.study_id=zz.study_id) as DOD from form_crf_3a as i left join form_crf_2 as j on i.assis_id=j.assis_id left join pw as k on k.id=i.assis_id left join dss_address l on k.dss_id=l.dss_id   left join studies as m on m.assis_id=k.id where DATEDIFF(CURDATE(),str_to_date(j.lw_crf2_21, '%d-%m-%Y')) >38 and i.lw_crf_3a_19='c' and  not exists (select a.form_crf_5a_id,a.followup_num,a.study_id from form_crf_5a as a where  m.study_id=a.study_id and a.form_crf_5a_id=(SELECT max(z.form_crf_5a_id) from form_crf_5a as z where a.study_id=z.study_id and (z.lw_crf5a_53='1' || z.lw_crf5a_53='2')) group by a.study_id)) as Table_A where Table_A.DOD!=''  group by Table_A.site ", con);
            {
                MySqlDataReader reader = cmd.ExecuteReader();
                DataTable dtData = new DataTable();
                dtData.Load(reader);
                return dtData;
                con.Close();
            }
            con.Close();
        }






        private void LoadChartDoseDayWise()
        {
            string query = string.Format("select 'Age <= 37',count(*) as total from (select z.form_crf_5a_id,z.followup_num,z.lw_crf5a_02,d.lw_crf2_21 as dob,z.study_id,a.study_code,DATEDIFF(str_to_date(z.lw_crf5a_02, '%d-%m-%Y'),str_to_date(d.lw_crf2_21 , '%d-%m-%Y')) as age,c.lw_crf_1_11 as site from form_crf_5a as z  left join studies as a on a.study_id=z.study_id 	left join pw as b on b.id=a.assis_id left join dss_address as c on c.dss_id=b.dss_id left join form_crf_2 as d on a.assis_id=d.assis_id    where  z.form_crf_5a_id in (select zz.form_crf_5a_id from form_crf_5a as zz where zz.study_id=z.study_id and  (zz.lw_crf5a_53=1 || zz.lw_crf5a_53=2)) group by a.study_code) as Table_A where age<=37     union all select 'Age 38',count(*) as total from (select z.form_crf_5a_id,z.followup_num,z.lw_crf5a_02,d.lw_crf2_21 as dob,z.study_id,a.study_code,DATEDIFF(str_to_date(z.lw_crf5a_02, '%d-%m-%Y'),str_to_date(d.lw_crf2_21 , '%d-%m-%Y')) as age,c.lw_crf_1_11 as site from form_crf_5a as z  left join studies as a on a.study_id=z.study_id 	left join pw as b on b.id=a.assis_id left join dss_address as c on c.dss_id=b.dss_id left join form_crf_2 as d on a.assis_id=d.assis_id    where  z.form_crf_5a_id in (select zz.form_crf_5a_id from form_crf_5a as zz where zz.study_id=z.study_id and  (zz.lw_crf5a_53=1 || zz.lw_crf5a_53=2)) group by a.study_code) as Table_A where age=38     union all select 'Age 39',count(*) as total from (select z.form_crf_5a_id,z.followup_num,z.lw_crf5a_02,d.lw_crf2_21 as dob,z.study_id,a.study_code,DATEDIFF(str_to_date(z.lw_crf5a_02, '%d-%m-%Y'),str_to_date(d.lw_crf2_21 , '%d-%m-%Y')) as age,c.lw_crf_1_11 as site from form_crf_5a as z  left join studies as a on a.study_id=z.study_id 	left join pw as b on b.id=a.assis_id left join dss_address as c on c.dss_id=b.dss_id left join form_crf_2 as d on a.assis_id=d.assis_id    where  z.form_crf_5a_id in (select zz.form_crf_5a_id from form_crf_5a as zz where zz.study_id=z.study_id and  (zz.lw_crf5a_53=1 || zz.lw_crf5a_53=2)) group by a.study_code) as Table_A where age=39    union all select 'Age 40',count(*) as total from (select z.form_crf_5a_id,z.followup_num,z.lw_crf5a_02,d.lw_crf2_21 as dob,z.study_id,a.study_code,DATEDIFF(str_to_date(z.lw_crf5a_02, '%d-%m-%Y'),str_to_date(d.lw_crf2_21 , '%d-%m-%Y')) as age,c.lw_crf_1_11 as site from form_crf_5a as z  left join studies as a on a.study_id=z.study_id 	left join pw as b on b.id=a.assis_id left join dss_address as c on c.dss_id=b.dss_id left join form_crf_2 as d on a.assis_id=d.assis_id    where  z.form_crf_5a_id in (select zz.form_crf_5a_id from form_crf_5a as zz where zz.study_id=z.study_id and  (zz.lw_crf5a_53=1 || zz.lw_crf5a_53=2)) group by a.study_code) as Table_A where age=40    union all select 'Age 41',count(*) as total from (select z.form_crf_5a_id,z.followup_num,z.lw_crf5a_02,d.lw_crf2_21 as dob,z.study_id,a.study_code,DATEDIFF(str_to_date(z.lw_crf5a_02, '%d-%m-%Y'),str_to_date(d.lw_crf2_21 , '%d-%m-%Y')) as age,c.lw_crf_1_11 as site from form_crf_5a as z  left join studies as a on a.study_id=z.study_id 	left join pw as b on b.id=a.assis_id left join dss_address as c on c.dss_id=b.dss_id left join form_crf_2 as d on a.assis_id=d.assis_id    where  z.form_crf_5a_id in (select zz.form_crf_5a_id from form_crf_5a as zz where zz.study_id=z.study_id and  (zz.lw_crf5a_53=1 || zz.lw_crf5a_53=2)) group by a.study_code) as Table_A where age=41    union all select 'Age 42',count(*) as total from (select z.form_crf_5a_id,z.followup_num,z.lw_crf5a_02,d.lw_crf2_21 as dob,z.study_id,a.study_code,DATEDIFF(str_to_date(z.lw_crf5a_02, '%d-%m-%Y'),str_to_date(d.lw_crf2_21 , '%d-%m-%Y')) as age,c.lw_crf_1_11 as site from form_crf_5a as z  left join studies as a on a.study_id=z.study_id 	left join pw as b on b.id=a.assis_id left join dss_address as c on c.dss_id=b.dss_id left join form_crf_2 as d on a.assis_id=d.assis_id    where  z.form_crf_5a_id in (select zz.form_crf_5a_id from form_crf_5a as zz where zz.study_id=z.study_id and  (zz.lw_crf5a_53=1 || zz.lw_crf5a_53=2)) group by a.study_code) as Table_A where age=42    union all select 'Age 43',count(*) as total from (select z.form_crf_5a_id,z.followup_num,z.lw_crf5a_02,d.lw_crf2_21 as dob,z.study_id,a.study_code,DATEDIFF(str_to_date(z.lw_crf5a_02, '%d-%m-%Y'),str_to_date(d.lw_crf2_21 , '%d-%m-%Y')) as age,c.lw_crf_1_11 as site from form_crf_5a as z  left join studies as a on a.study_id=z.study_id 	left join pw as b on b.id=a.assis_id left join dss_address as c on c.dss_id=b.dss_id left join form_crf_2 as d on a.assis_id=d.assis_id    where  z.form_crf_5a_id in (select zz.form_crf_5a_id from form_crf_5a as zz where zz.study_id=z.study_id and  (zz.lw_crf5a_53=1 || zz.lw_crf5a_53=2)) group by a.study_code) as Table_A where age=43    union all select 'Age 44',count(*) as total from (select z.form_crf_5a_id,z.followup_num,z.lw_crf5a_02,d.lw_crf2_21 as dob,z.study_id,a.study_code,DATEDIFF(str_to_date(z.lw_crf5a_02, '%d-%m-%Y'),str_to_date(d.lw_crf2_21 , '%d-%m-%Y')) as age,c.lw_crf_1_11 as site from form_crf_5a as z  left join studies as a on a.study_id=z.study_id 	left join pw as b on b.id=a.assis_id left join dss_address as c on c.dss_id=b.dss_id left join form_crf_2 as d on a.assis_id=d.assis_id    where  z.form_crf_5a_id in (select zz.form_crf_5a_id from form_crf_5a as zz where zz.study_id=z.study_id and  (zz.lw_crf5a_53=1 || zz.lw_crf5a_53=2)) group by a.study_code) as Table_A where age=44    union all select 'Age 45',count(*) as total from (select z.form_crf_5a_id,z.followup_num,z.lw_crf5a_02,d.lw_crf2_21 as dob,z.study_id,a.study_code,DATEDIFF(str_to_date(z.lw_crf5a_02, '%d-%m-%Y'),str_to_date(d.lw_crf2_21 , '%d-%m-%Y')) as age,c.lw_crf_1_11 as site from form_crf_5a as z  left join studies as a on a.study_id=z.study_id 	left join pw as b on b.id=a.assis_id left join dss_address as c on c.dss_id=b.dss_id left join form_crf_2 as d on a.assis_id=d.assis_id    where  z.form_crf_5a_id in (select zz.form_crf_5a_id from form_crf_5a as zz where zz.study_id=z.study_id and  (zz.lw_crf5a_53=1 || zz.lw_crf5a_53=2)) group by a.study_code) as Table_A where age=45    union all select 'Age 46',count(*) as total from (select z.form_crf_5a_id,z.followup_num,z.lw_crf5a_02,d.lw_crf2_21 as dob,z.study_id,a.study_code,DATEDIFF(str_to_date(z.lw_crf5a_02, '%d-%m-%Y'),str_to_date(d.lw_crf2_21 , '%d-%m-%Y')) as age,c.lw_crf_1_11 as site from form_crf_5a as z  left join studies as a on a.study_id=z.study_id 	left join pw as b on b.id=a.assis_id left join dss_address as c on c.dss_id=b.dss_id left join form_crf_2 as d on a.assis_id=d.assis_id    where  z.form_crf_5a_id in (select zz.form_crf_5a_id from form_crf_5a as zz where zz.study_id=z.study_id and  (zz.lw_crf5a_53=1 || zz.lw_crf5a_53=2)) group by a.study_code) as Table_A where age=46    union all select 'Age 47',count(*) as total from (select z.form_crf_5a_id,z.followup_num,z.lw_crf5a_02,d.lw_crf2_21 as dob,z.study_id,a.study_code,DATEDIFF(str_to_date(z.lw_crf5a_02, '%d-%m-%Y'),str_to_date(d.lw_crf2_21 , '%d-%m-%Y')) as age,c.lw_crf_1_11 as site from form_crf_5a as z  left join studies as a on a.study_id=z.study_id 	left join pw as b on b.id=a.assis_id left join dss_address as c on c.dss_id=b.dss_id left join form_crf_2 as d on a.assis_id=d.assis_id    where  z.form_crf_5a_id in (select zz.form_crf_5a_id from form_crf_5a as zz where zz.study_id=z.study_id and  (zz.lw_crf5a_53=1 || zz.lw_crf5a_53=2)) group by a.study_code) as Table_A where age=47    union all select 'Age 48',count(*) as total from (select z.form_crf_5a_id,z.followup_num,z.lw_crf5a_02,d.lw_crf2_21 as dob,z.study_id,a.study_code,DATEDIFF(str_to_date(z.lw_crf5a_02, '%d-%m-%Y'),str_to_date(d.lw_crf2_21 , '%d-%m-%Y')) as age,c.lw_crf_1_11 as site from form_crf_5a as z  left join studies as a on a.study_id=z.study_id 	left join pw as b on b.id=a.assis_id left join dss_address as c on c.dss_id=b.dss_id left join form_crf_2 as d on a.assis_id=d.assis_id    where  z.form_crf_5a_id in (select zz.form_crf_5a_id from form_crf_5a as zz where zz.study_id=z.study_id and  (zz.lw_crf5a_53=1 || zz.lw_crf5a_53=2)) group by a.study_code) as Table_A where age=48    union all select 'Age 49',count(*) as total from (select z.form_crf_5a_id,z.followup_num,z.lw_crf5a_02,d.lw_crf2_21 as dob,z.study_id,a.study_code,DATEDIFF(str_to_date(z.lw_crf5a_02, '%d-%m-%Y'),str_to_date(d.lw_crf2_21 , '%d-%m-%Y')) as age,c.lw_crf_1_11 as site from form_crf_5a as z  left join studies as a on a.study_id=z.study_id 	left join pw as b on b.id=a.assis_id left join dss_address as c on c.dss_id=b.dss_id left join form_crf_2 as d on a.assis_id=d.assis_id    where  z.form_crf_5a_id in (select zz.form_crf_5a_id from form_crf_5a as zz where zz.study_id=z.study_id and  (zz.lw_crf5a_53=1 || zz.lw_crf5a_53=2)) group by a.study_code) as Table_A where age=49    union all select 'Age 50',count(*) as total from (select z.form_crf_5a_id,z.followup_num,z.lw_crf5a_02,d.lw_crf2_21 as dob,z.study_id,a.study_code,DATEDIFF(str_to_date(z.lw_crf5a_02, '%d-%m-%Y'),str_to_date(d.lw_crf2_21 , '%d-%m-%Y')) as age,c.lw_crf_1_11 as site from form_crf_5a as z  left join studies as a on a.study_id=z.study_id 	left join pw as b on b.id=a.assis_id left join dss_address as c on c.dss_id=b.dss_id left join form_crf_2 as d on a.assis_id=d.assis_id    where  z.form_crf_5a_id in (select zz.form_crf_5a_id from form_crf_5a as zz where zz.study_id=z.study_id and  (zz.lw_crf5a_53=1 || zz.lw_crf5a_53=2)) group by a.study_code) as Table_A where age=50    union all select 'Age 51',count(*) as total from (select z.form_crf_5a_id,z.followup_num,z.lw_crf5a_02,d.lw_crf2_21 as dob,z.study_id,a.study_code,DATEDIFF(str_to_date(z.lw_crf5a_02, '%d-%m-%Y'),str_to_date(d.lw_crf2_21 , '%d-%m-%Y')) as age,c.lw_crf_1_11 as site from form_crf_5a as z  left join studies as a on a.study_id=z.study_id 	left join pw as b on b.id=a.assis_id left join dss_address as c on c.dss_id=b.dss_id left join form_crf_2 as d on a.assis_id=d.assis_id    where  z.form_crf_5a_id in (select zz.form_crf_5a_id from form_crf_5a as zz where zz.study_id=z.study_id and  (zz.lw_crf5a_53=1 || zz.lw_crf5a_53=2)) group by a.study_code) as Table_A where age=51    union all select 'Age 52',count(*) as total from (select z.form_crf_5a_id,z.followup_num,z.lw_crf5a_02,d.lw_crf2_21 as dob,z.study_id,a.study_code,DATEDIFF(str_to_date(z.lw_crf5a_02, '%d-%m-%Y'),str_to_date(d.lw_crf2_21 , '%d-%m-%Y')) as age,c.lw_crf_1_11 as site from form_crf_5a as z  left join studies as a on a.study_id=z.study_id 	left join pw as b on b.id=a.assis_id left join dss_address as c on c.dss_id=b.dss_id left join form_crf_2 as d on a.assis_id=d.assis_id    where  z.form_crf_5a_id in (select zz.form_crf_5a_id from form_crf_5a as zz where zz.study_id=z.study_id and  (zz.lw_crf5a_53=1 || zz.lw_crf5a_53=2)) group by a.study_code) as Table_A where age=52    union all select 'Age >= 53',count(*) as total from (select z.form_crf_5a_id,z.followup_num,z.lw_crf5a_02,d.lw_crf2_21 as dob,z.study_id,a.study_code,DATEDIFF(str_to_date(z.lw_crf5a_02, '%d-%m-%Y'),str_to_date(d.lw_crf2_21 , '%d-%m-%Y')) as age,c.lw_crf_1_11 as site from form_crf_5a as z  left join studies as a on a.study_id=z.study_id 	left join pw as b on b.id=a.assis_id left join dss_address as c on c.dss_id=b.dss_id left join form_crf_2 as d on a.assis_id=d.assis_id    where  z.form_crf_5a_id in (select zz.form_crf_5a_id from form_crf_5a as zz where zz.study_id=z.study_id and  (zz.lw_crf5a_53=1 || zz.lw_crf5a_53=2)) group by a.study_code) as Table_A where age>=53");
            DataTable dt = GetData(query);
            Chart3.DataSource = dt;
            Chart3.Series[0].XValueMember = "Age <= 37";
            Chart3.Series[0].YValueMembers = "total";
            Chart3.Series[0].Label = "#VALY";
            Chart3.ChartAreas["ChartArea3"].AxisX.MajorGrid.Enabled = false;
            Chart3.Series["Series3"].IsValueShownAsLabel = true;
            Chart3.DataBind();
        }






        private void LoadChartAllSite()
        {
            string query = string.Format("select 'Eligible, Cumulative', count(*) as total from (select count(*) from view_vaccination where arm ='c' and current_age >= 42 group by study_code)  as Table_A union all select 'Dose Received, Cumulative',count(*) from (select z.form_crf_5a_id,z.followup_num,z.lw_crf5a_02,d.lw_crf2_21 as dob,z.study_id,a.study_code,DATEDIFF(str_to_date(z.lw_crf5a_02, '%d-%m-%Y'),str_to_date(d.lw_crf2_21 , '%d-%m-%Y')) as age,c.lw_crf_1_11 as site from form_crf_5a as z  left join studies as a on a.study_id=z.study_id 	left join pw as b on b.id=a.assis_id left join dss_address as c on c.dss_id=b.dss_id left join form_crf_2 as d on a.assis_id=d.assis_id    where  z.form_crf_5a_id in (select zz.form_crf_5a_id from form_crf_5a as zz where zz.study_id=z.study_id and  (zz.lw_crf5a_53=1 || zz.lw_crf5a_53=2)) group by a.study_code) as Table_A union all select 'Dose Received less than 42 days',count(*) as total from (select z.form_crf_5a_id,z.followup_num,z.lw_crf5a_02,d.lw_crf2_21 as dob,z.study_id,a.study_code,DATEDIFF(str_to_date(z.lw_crf5a_02, '%d-%m-%Y'),str_to_date(d.lw_crf2_21 , '%d-%m-%Y')) as age,c.lw_crf_1_11 as site from form_crf_5a as z  left join studies as a on a.study_id=z.study_id 	left join pw as b on b.id=a.assis_id left join dss_address as c on c.dss_id=b.dss_id left join form_crf_2 as d on a.assis_id=d.assis_id    where  z.form_crf_5a_id in (select zz.form_crf_5a_id from form_crf_5a as zz where zz.study_id=z.study_id and  (zz.lw_crf5a_53=1 || zz.lw_crf5a_53=2)) group by a.study_code) as Table_A where age<42 			 union all select 'Dose Received Age between 42 to 44 days',count(*) as total from (select z.form_crf_5a_id,z.followup_num,z.lw_crf5a_02,d.lw_crf2_21 as dob,z.study_id,a.study_code,DATEDIFF(str_to_date(z.lw_crf5a_02, '%d-%m-%Y'),str_to_date(d.lw_crf2_21 , '%d-%m-%Y')) as age,c.lw_crf_1_11 as site from form_crf_5a as z  left join studies as a on a.study_id=z.study_id 	left join pw as b on b.id=a.assis_id left join dss_address as c on c.dss_id=b.dss_id left join form_crf_2 as d on a.assis_id=d.assis_id    where  z.form_crf_5a_id in (select zz.form_crf_5a_id from form_crf_5a as zz where zz.study_id=z.study_id and  (zz.lw_crf5a_53=1 || zz.lw_crf5a_53=2)) group by a.study_code) as Table_A where age>=42  and age<=44   union all select 'Dose Received Age greater than 44 days',count(*) as total from (select z.form_crf_5a_id,z.followup_num,z.lw_crf5a_02,d.lw_crf2_21 as dob,z.study_id,a.study_code,DATEDIFF(str_to_date(z.lw_crf5a_02, '%d-%m-%Y'),str_to_date(d.lw_crf2_21 , '%d-%m-%Y')) as age,c.lw_crf_1_11 as site from form_crf_5a as z  left join studies as a on a.study_id=z.study_id 	left join pw as b on b.id=a.assis_id left join dss_address as c on c.dss_id=b.dss_id left join form_crf_2 as d on a.assis_id=d.assis_id    where  z.form_crf_5a_id in (select zz.form_crf_5a_id from form_crf_5a as zz where zz.study_id=z.study_id and  (zz.lw_crf5a_53=1 || zz.lw_crf5a_53=2)) group by a.study_code) as Table_A where age>=42  and age>44   union all select 'Dose Pending (Cumulative), Age greater than 42 days',count(*) as total from   (select i.lw_crf_3a_4 as study_id,l.lw_crf_1_11 as site,i.lw_crf_3a_18 as random_id, j.lw_crf2_21 as dob,DATE_FORMAT(AddDate((str_to_date(j.lw_crf2_21, '%d-%m-%Y')), interval 42 DAY),'%d-%m-%Y') as  Age_Day_42,  DATEDIFF(CURDATE(),str_to_date(j.lw_crf2_21, '%d-%m-%Y')) as current_age, j.date_of_attempt as enrollment,k.lw_crf1_09 as woman_nm, k.lw_crf1_10 as husband_nm, concat(l.lw_crf_1_11,l.lw_crf_1_12,l.lw_crf_1_13,l.lw_crf_1_14,l.lw_crf_1_15,l.lw_crf_1_16) as dssid, (select zz.lw_crf4a_24 from form_crf_4a as zz  where zz.lw_crf4a_23=2 and m.study_id=zz.study_id) as DOD from form_crf_3a as i left join form_crf_2 as j on i.assis_id=j.assis_id left join pw as k on k.id=i.assis_id left join dss_address l on k.dss_id=l.dss_id   left join studies as m on m.assis_id=k.id where DATEDIFF(CURDATE(),str_to_date(j.lw_crf2_21, '%d-%m-%Y')) >42		and i.lw_crf_3a_19='c' and  not exists (select a.form_crf_5a_id,a.followup_num,a.study_id from form_crf_5a as a where  m.study_id=a.study_id and a.form_crf_5a_id=(SELECT max(z.form_crf_5a_id) from form_crf_5a as z where a.study_id=z.study_id and (z.lw_crf5a_53='1' || z.lw_crf5a_53='2')) group by a.study_id)) as Table_A   union all select 'Dose Pending (Refusal), Age greater than 42 days',count(*) as total from   (select i.lw_crf_3a_4 as study_id,l.lw_crf_1_11 as site,i.lw_crf_3a_18 as random_id, j.lw_crf2_21 as dob,DATE_FORMAT(AddDate((str_to_date(j.lw_crf2_21, '%d-%m-%Y')), interval 42 DAY),'%d-%m-%Y') as  Age_Day_42,  DATEDIFF(CURDATE(),str_to_date(j.lw_crf2_21, '%d-%m-%Y')) as current_age, j.date_of_attempt as enrollment,k.lw_crf1_09 as woman_nm, k.lw_crf1_10 as husband_nm, concat(l.lw_crf_1_11,l.lw_crf_1_12,l.lw_crf_1_13,l.lw_crf_1_14,l.lw_crf_1_15,l.lw_crf_1_16) as dssid, (select zz.lw_crf4a_24 from form_crf_4a as zz  where zz.lw_crf4a_23=2 and m.study_id=zz.study_id) as DOD from form_crf_3a as i left join form_crf_2 as j on i.assis_id=j.assis_id left join pw as k on k.id=i.assis_id left join dss_address l on k.dss_id=l.dss_id   left join studies as m on m.assis_id=k.id where DATEDIFF(CURDATE(),str_to_date(j.lw_crf2_21, '%d-%m-%Y')) >=42	 		and i.lw_crf_3a_19='c' and  not exists (select a.form_crf_5a_id,a.followup_num,a.study_id from form_crf_5a as a where  m.study_id=a.study_id and a.form_crf_5a_id=(SELECT max(z.form_crf_5a_id) from form_crf_5a as z where a.study_id=z.study_id and (z.lw_crf5a_53='1' || z.lw_crf5a_53='2')) group by a.study_id)) as Table_A where Table_A.current_age >42 and (Table_A.DOD='' or Table_A.DOD is null)  union all select 'Dose Pending, due to Child Death',count(*) as total from   (select i.lw_crf_3a_4 as study_id,l.lw_crf_1_11 as site,i.lw_crf_3a_18 as random_id, j.lw_crf2_21 as dob,DATE_FORMAT(AddDate((str_to_date(j.lw_crf2_21, '%d-%m-%Y')), interval 42 DAY),'%d-%m-%Y') as  Age_Day_42,  DATEDIFF(CURDATE(),str_to_date(j.lw_crf2_21, '%d-%m-%Y')) as current_age, j.date_of_attempt as enrollment,k.lw_crf1_09 as woman_nm, k.lw_crf1_10 as husband_nm, concat(l.lw_crf_1_11,l.lw_crf_1_12,l.lw_crf_1_13,l.lw_crf_1_14,l.lw_crf_1_15,l.lw_crf_1_16) as dssid, (select zz.lw_crf4a_24 from form_crf_4a as zz  where zz.lw_crf4a_23=2 and m.study_id=zz.study_id) as DOD from form_crf_3a as i left join form_crf_2 as j on i.assis_id=j.assis_id left join pw as k on k.id=i.assis_id left join dss_address l on k.dss_id=l.dss_id   left join studies as m on m.assis_id=k.id where DATEDIFF(CURDATE(),str_to_date(j.lw_crf2_21, '%d-%m-%Y')) >=42				and i.lw_crf_3a_19='c' and  not exists (select a.form_crf_5a_id,a.followup_num,a.study_id from form_crf_5a as a where  m.study_id=a.study_id and a.form_crf_5a_id=(SELECT max(z.form_crf_5a_id) from form_crf_5a as z where a.study_id=z.study_id and (z.lw_crf5a_53='1' || z.lw_crf5a_53='2')) group by a.study_id)) as Table_A where Table_A.DOD!=''");
            // string query = string.Format("select 'Dose Received, Cumulative',count(*) as total from (select z.form_crf_5a_id,z.followup_num,z.lw_crf5a_02,d.lw_crf2_21 as dob,z.study_id,a.study_code,DATEDIFF(str_to_date(z.lw_crf5a_02, '%d-%m-%Y'),str_to_date(d.lw_crf2_21 , '%d-%m-%Y')) as age,c.lw_crf_1_11 as site from form_crf_5a as z  left join studies as a on a.study_id=z.study_id 	left join pw as b on b.id=a.assis_id left join dss_address as c on c.dss_id=b.dss_id left join form_crf_2 as d on a.assis_id=d.assis_id    where  z.form_crf_5a_id in (select zz.form_crf_5a_id from form_crf_5a as zz where zz.study_id=z.study_id and  (zz.lw_crf5a_53=1 || zz.lw_crf5a_53=2)) group by a.study_code) as Table_A union all select 'Dose Received less and equal than 42 days',count(*) as total from (select z.form_crf_5a_id,z.followup_num,z.lw_crf5a_02,d.lw_crf2_21 as dob,z.study_id,a.study_code,DATEDIFF(str_to_date(z.lw_crf5a_02, '%d-%m-%Y'),str_to_date(d.lw_crf2_21 , '%d-%m-%Y')) as age,c.lw_crf_1_11 as site from form_crf_5a as z  left join studies as a on a.study_id=z.study_id 	left join pw as b on b.id=a.assis_id left join dss_address as c on c.dss_id=b.dss_id left join form_crf_2 as d on a.assis_id=d.assis_id    where  z.form_crf_5a_id in (select zz.form_crf_5a_id from form_crf_5a as zz where zz.study_id=z.study_id and  (zz.lw_crf5a_53=1 || zz.lw_crf5a_53=2)) group by a.study_code) as Table_A where age<=42  union all select 'Dose Received greater than 42 days',count(*) as total from (select z.form_crf_5a_id,z.followup_num,z.lw_crf5a_02,d.lw_crf2_21 as dob,z.study_id,a.study_code,DATEDIFF(str_to_date(z.lw_crf5a_02, '%d-%m-%Y'),str_to_date(d.lw_crf2_21 , '%d-%m-%Y')) as age,c.lw_crf_1_11 as site from form_crf_5a as z  left join studies as a on a.study_id=z.study_id 	left join pw as b on b.id=a.assis_id left join dss_address as c on c.dss_id=b.dss_id left join form_crf_2 as d on a.assis_id=d.assis_id    where  z.form_crf_5a_id in (select zz.form_crf_5a_id from form_crf_5a as zz where zz.study_id=z.study_id and  (zz.lw_crf5a_53=1 || zz.lw_crf5a_53=2)) group by a.study_code) as Table_A where age>42  union all select 'Dose Pending, Cumulative (Age greater than 38 days)',count(*) as total from   (select i.lw_crf_3a_4 as study_id,l.lw_crf_1_11 as site,i.lw_crf_3a_18 as random_id, j.lw_crf2_21 as dob,DATE_FORMAT(AddDate((str_to_date(j.lw_crf2_21, '%d-%m-%Y')), interval 42 DAY),'%d-%m-%Y') as  Age_Day_42,  DATEDIFF(CURDATE(),str_to_date(j.lw_crf2_21, '%d-%m-%Y')) as current_age, j.date_of_attempt as enrollment,k.lw_crf1_09 as woman_nm, k.lw_crf1_10 as husband_nm, concat(l.lw_crf_1_11,l.lw_crf_1_12,l.lw_crf_1_13,l.lw_crf_1_14,l.lw_crf_1_15,l.lw_crf_1_16) as dssid, (select zz.lw_crf4a_24 from form_crf_4a as zz  where zz.lw_crf4a_23=2 and m.study_id=zz.study_id) as DOD from form_crf_3a as i left join form_crf_2 as j on i.assis_id=j.assis_id left join pw as k on k.id=i.assis_id left join dss_address l on k.dss_id=l.dss_id   left join studies as m on m.assis_id=k.id where DATEDIFF(CURDATE(),str_to_date(j.lw_crf2_21, '%d-%m-%Y')) >38 and i.lw_crf_3a_19='c' and  not exists (select a.form_crf_5a_id,a.followup_num,a.study_id from form_crf_5a as a where  m.study_id=a.study_id and a.form_crf_5a_id=(SELECT max(z.form_crf_5a_id) from form_crf_5a as z where a.study_id=z.study_id and (z.lw_crf5a_53='1' || z.lw_crf5a_53='2')) group by a.study_id)) as Table_A  union all select 'Dose Pending, Age greater than 40 days',count(*) as total from   (select i.lw_crf_3a_4 as study_id,l.lw_crf_1_11 as site,i.lw_crf_3a_18 as random_id, j.lw_crf2_21 as dob,DATE_FORMAT(AddDate((str_to_date(j.lw_crf2_21, '%d-%m-%Y')), interval 42 DAY),'%d-%m-%Y') as  Age_Day_42,  DATEDIFF(CURDATE(),str_to_date(j.lw_crf2_21, '%d-%m-%Y')) as current_age, j.date_of_attempt as enrollment,k.lw_crf1_09 as woman_nm, k.lw_crf1_10 as husband_nm, concat(l.lw_crf_1_11,l.lw_crf_1_12,l.lw_crf_1_13,l.lw_crf_1_14,l.lw_crf_1_15,l.lw_crf_1_16) as dssid, (select zz.lw_crf4a_24 from form_crf_4a as zz  where zz.lw_crf4a_23=2 and m.study_id=zz.study_id) as DOD from form_crf_3a as i left join form_crf_2 as j on i.assis_id=j.assis_id left join pw as k on k.id=i.assis_id left join dss_address l on k.dss_id=l.dss_id   left join studies as m on m.assis_id=k.id where DATEDIFF(CURDATE(),str_to_date(j.lw_crf2_21, '%d-%m-%Y')) >38 and i.lw_crf_3a_19='c' and  not exists (select a.form_crf_5a_id,a.followup_num,a.study_id from form_crf_5a as a where  m.study_id=a.study_id and a.form_crf_5a_id=(SELECT max(z.form_crf_5a_id) from form_crf_5a as z where a.study_id=z.study_id and (z.lw_crf5a_53='1' || z.lw_crf5a_53='2')) group by a.study_id)) as Table_A where Table_A.current_age >40 and (Table_A.DOD='' or Table_A.DOD is null) union all select 'Dose Pending, Age less and Equal than 40 days',count(*) as total from   (select i.lw_crf_3a_4 as study_id,l.lw_crf_1_11 as site,i.lw_crf_3a_18 as random_id, j.lw_crf2_21 as dob,DATE_FORMAT(AddDate((str_to_date(j.lw_crf2_21, '%d-%m-%Y')), interval 42 DAY),'%d-%m-%Y') as  Age_Day_42,  DATEDIFF(CURDATE(),str_to_date(j.lw_crf2_21, '%d-%m-%Y')) as current_age, j.date_of_attempt as enrollment,k.lw_crf1_09 as woman_nm, k.lw_crf1_10 as husband_nm, concat(l.lw_crf_1_11,l.lw_crf_1_12,l.lw_crf_1_13,l.lw_crf_1_14,l.lw_crf_1_15,l.lw_crf_1_16) as dssid, (select zz.lw_crf4a_24 from form_crf_4a as zz  where zz.lw_crf4a_23=2 and m.study_id=zz.study_id) as DOD from form_crf_3a as i left join form_crf_2 as j on i.assis_id=j.assis_id left join pw as k on k.id=i.assis_id left join dss_address l on k.dss_id=l.dss_id   left join studies as m on m.assis_id=k.id where DATEDIFF(CURDATE(),str_to_date(j.lw_crf2_21, '%d-%m-%Y')) >38 and i.lw_crf_3a_19='c' and  not exists (select a.form_crf_5a_id,a.followup_num,a.study_id from form_crf_5a as a where  m.study_id=a.study_id and a.form_crf_5a_id=(SELECT max(z.form_crf_5a_id) from form_crf_5a as z where a.study_id=z.study_id and (z.lw_crf5a_53='1' || z.lw_crf5a_53='2')) group by a.study_id)) as Table_A where Table_A.current_age <=40 and (Table_A.DOD='' or Table_A.DOD is null)  union all select 'Dose Pending, due to Child Death',count(*) as total from   (select i.lw_crf_3a_4 as study_id,l.lw_crf_1_11 as site,i.lw_crf_3a_18 as random_id, j.lw_crf2_21 as dob,DATE_FORMAT(AddDate((str_to_date(j.lw_crf2_21, '%d-%m-%Y')), interval 42 DAY),'%d-%m-%Y') as  Age_Day_42,  DATEDIFF(CURDATE(),str_to_date(j.lw_crf2_21, '%d-%m-%Y')) as current_age, j.date_of_attempt as enrollment,k.lw_crf1_09 as woman_nm, k.lw_crf1_10 as husband_nm, concat(l.lw_crf_1_11,l.lw_crf_1_12,l.lw_crf_1_13,l.lw_crf_1_14,l.lw_crf_1_15,l.lw_crf_1_16) as dssid, (select zz.lw_crf4a_24 from form_crf_4a as zz  where zz.lw_crf4a_23=2 and m.study_id=zz.study_id) as DOD from form_crf_3a as i left join form_crf_2 as j on i.assis_id=j.assis_id left join pw as k on k.id=i.assis_id left join dss_address l on k.dss_id=l.dss_id   left join studies as m on m.assis_id=k.id where DATEDIFF(CURDATE(),str_to_date(j.lw_crf2_21, '%d-%m-%Y')) >38 and i.lw_crf_3a_19='c' and  not exists (select a.form_crf_5a_id,a.followup_num,a.study_id from form_crf_5a as a where  m.study_id=a.study_id and a.form_crf_5a_id=(SELECT max(z.form_crf_5a_id) from form_crf_5a as z where a.study_id=z.study_id and (z.lw_crf5a_53='1' || z.lw_crf5a_53='2')) group by a.study_id)) as Table_A where Table_A.DOD!=''");
            DataTable dt = GetData(query);
            Chart2.DataSource = dt;
            Chart2.Series[0].XValueMember = "Eligible, Cumulative";
            Chart2.Series[0].YValueMembers = "total";
            Chart2.Series[0].Label = "#VALY";
            Chart2.ChartAreas["ChartArea2"].AxisX.MajorGrid.Enabled = false;
            Chart2.DataBind();
        }


        //For Graph Cumulative:

        private static DataTable GetData(string query)
        {
            string constr = ConfigurationManager.ConnectionStrings["LocalMySql"].ConnectionString;

            MySqlConnection con = new MySqlConnection(constr);
            {
                using (MySqlCommand cmd = new MySqlCommand(query))
                {
                    DataTable dt = new DataTable();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter(query, con))
                    {
                        sda.Fill(dt);
                    }
                    return dt;
                }
            }
        }





















        protected void btnSearchPending_Click(object sender, EventArgs e)
        {
            ShowDataPending();
            txtdssidPending.Focus();
        }


        private void ShowDataPending()
        {
            MySqlConnection con = new MySqlConnection(constr);
            try
            {
                if (DropDownList1.SelectedValue == "0")
                {
                    con.Open();
                    MySqlCommand cmd;
                    cmd = new MySqlCommand("select i.lw_crf_3a_4 as study_id,i.lw_crf_3a_18 as random_id, j.lw_crf2_21 as dob,DATE_FORMAT(AddDate((str_to_date(j.lw_crf2_21, '%d-%m-%Y')), interval 42 DAY),'%d-%m-%Y') as  Age_Day_42, DATEDIFF(CURDATE(),str_to_date(j.lw_crf2_21, '%d-%m-%Y')) as current_age, j.date_of_attempt as enrollment,k.lw_crf1_09 as woman_nm, k.lw_crf1_10 as husband_nm, concat(l.lw_crf_1_11,l.lw_crf_1_12,l.lw_crf_1_13,l.lw_crf_1_14,l.lw_crf_1_15,l.lw_crf_1_16) as dssid, (select zz.lw_crf4a_24 from form_crf_4a as zz  where zz.lw_crf4a_23=2 and m.study_id=zz.study_id) as DOD from form_crf_3a as i left join form_crf_2 as j on i.assis_id=j.assis_id left join pw as k on k.id=i.assis_id left join dss_address l on k.dss_id=l.dss_id   left join studies as m on m.assis_id=k.id where DATEDIFF(CURDATE(),str_to_date(j.lw_crf2_21, '%d-%m-%Y')) >38  and i.lw_crf_3a_19='c' and concat(l.lw_crf_1_11,l.lw_crf_1_12,l.lw_crf_1_13,l.lw_crf_1_14,l.lw_crf_1_15,l.lw_crf_1_16) like '%" + txtdssidPending.Text + "%' and not exists (select a.form_crf_5a_id,a.followup_num,a.study_id from form_crf_5a as a where  m.study_id=a.study_id  and a.form_crf_5a_id=(SELECT max(z.form_crf_5a_id) from form_crf_5a as z where a.study_id=z.study_id and (z.lw_crf5a_53='1' || z.lw_crf5a_53='2')) group by a.study_id)", con);
                    MySqlDataAdapter sda = new MySqlDataAdapter();
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        DataTable dt = new DataTable();
                        {
                            sda.Fill(dt);
                            GridView1.DataSource = dt;
                            GridView1.DataBind();
                            con.Close();
                        }
                    }
                }
                else
                {
                    con.Open();
                    MySqlCommand cmd;
                    cmd = new MySqlCommand("select i.lw_crf_3a_4 as study_id,i.lw_crf_3a_18 as random_id, j.lw_crf2_21 as dob,DATE_FORMAT(AddDate((str_to_date(j.lw_crf2_21, '%d-%m-%Y')), interval 42 DAY),'%d-%m-%Y') as  Age_Day_42, DATEDIFF(CURDATE(),str_to_date(j.lw_crf2_21, '%d-%m-%Y')) as current_age, j.date_of_attempt as enrollment,k.lw_crf1_09 as woman_nm, k.lw_crf1_10 as husband_nm, concat(l.lw_crf_1_11,l.lw_crf_1_12,l.lw_crf_1_13,l.lw_crf_1_14,l.lw_crf_1_15,l.lw_crf_1_16) as dssid, (select zz.lw_crf4a_24 from form_crf_4a as zz  where zz.lw_crf4a_23=2 and m.study_id=zz.study_id) as DOD from form_crf_3a as i left join form_crf_2 as j on i.assis_id=j.assis_id left join pw as k on k.id=i.assis_id left join dss_address l on k.dss_id=l.dss_id   left join studies as m on m.assis_id=k.id where DATEDIFF(CURDATE(),str_to_date(j.lw_crf2_21, '%d-%m-%Y')) >38 and i.lw_crf_3a_19='c' and l.lw_crf_1_11='" + DropDownList1.SelectedValue + "' and concat(l.lw_crf_1_11,l.lw_crf_1_12,l.lw_crf_1_13,l.lw_crf_1_14,l.lw_crf_1_15,l.lw_crf_1_16) like '%" + txtdssidPending.Text + "%' and not exists (select a.form_crf_5a_id,a.followup_num,a.study_id from form_crf_5a as a where  m.study_id=a.study_id  and a.form_crf_5a_id=(SELECT max(z.form_crf_5a_id) from form_crf_5a as z where a.study_id=z.study_id and (z.lw_crf5a_53='1' || z.lw_crf5a_53='2')) group by a.study_id)", con);
                    MySqlDataAdapter sda = new MySqlDataAdapter();
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        DataTable dt = new DataTable();
                        {
                            sda.Fill(dt);
                            GridView1.DataSource = dt;
                            GridView1.DataBind();
                            con.Close();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script type=\"text/javascript\">alert('" + ex.Message + "')</script>");
            }
            finally
            {
                con.Close();
            }
        }




        protected void OnRowDataBound1(object sender, GridViewRowEventArgs e)
        {

        }




        protected void btnExportPending_Click(object sender, EventArgs e)
        {
            ShowDataPending();
            if (GridView1.Rows.Count != 0)
            {
                ExcelExportPending();
            }
            txtdssidPending.Focus();
        }





        public override void VerifyRenderingInServerForm(Control control)
        {
            //base.VerifyRenderingInServerForm(control);
        }


        private void ExcelExportP()
        {
            MySqlConnection con = new MySqlConnection(constr);
            try
            {
                if (DropDownList1.SelectedValue == "0")
                {
                    con.Open();
                    MySqlCommand cmd;
                    cmd = new MySqlCommand("select i.lw_crf_3a_4 as study_id,i.lw_crf_3a_18 as random_id, j.lw_crf2_21 as dob,DATE_FORMAT(AddDate((str_to_date(j.lw_crf2_21, '%d-%m-%Y')), interval 42 DAY),'%d-%m-%Y') as  Age_Day_42, DATEDIFF(CURDATE(),str_to_date(j.lw_crf2_21, '%d-%m-%Y')) as current_age, j.date_of_attempt as enrollment,k.lw_crf1_09 as woman_nm, k.lw_crf1_10 as husband_nm, concat(l.lw_crf_1_11,l.lw_crf_1_12,l.lw_crf_1_13,l.lw_crf_1_14,l.lw_crf_1_15,l.lw_crf_1_16) as dssid, (select zz.lw_crf4a_24 from form_crf_4a as zz  where zz.lw_crf4a_23=2 and m.study_id=zz.study_id) as DOD from form_crf_3a as i left join form_crf_2 as j on i.assis_id=j.assis_id left join pw as k on k.id=i.assis_id left join dss_address l on k.dss_id=l.dss_id   left join studies as m on m.assis_id=k.id where DATEDIFF(CURDATE(),str_to_date(j.lw_crf2_21, '%d-%m-%Y')) >38 and i.lw_crf_3a_19='c' and concat(l.lw_crf_1_11,l.lw_crf_1_12,l.lw_crf_1_13,l.lw_crf_1_14,l.lw_crf_1_15,l.lw_crf_1_16) like '%" + txtdssidPending.Text + "%' and not exists (select a.form_crf_5a_id,a.followup_num,a.study_id from form_crf_5a as a where  m.study_id=a.study_id and a.form_crf_5a_id=(SELECT max(z.form_crf_5a_id) from form_crf_5a as z where a.study_id=z.study_id and (z.lw_crf5a_53='1' || z.lw_crf5a_53='2')) group by a.study_id)", con);

                    MySqlDataAdapter sda = new MySqlDataAdapter();
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        DataTable dt = new DataTable();
                        {
                            sda.Fill(dt);
                            GridView2.DataSource = dt;
                            GridView2.DataBind();
                            con.Close();
                        }
                    }
                }
                else
                {
                    con.Open();
                    MySqlCommand cmd;
                    cmd = new MySqlCommand("select i.lw_crf_3a_4 as study_id,i.lw_crf_3a_18 as random_id, j.lw_crf2_21 as dob,DATE_FORMAT(AddDate((str_to_date(j.lw_crf2_21, '%d-%m-%Y')), interval 42 DAY),'%d-%m-%Y') as  Age_Day_42, DATEDIFF(CURDATE(),str_to_date(j.lw_crf2_21, '%d-%m-%Y')) as current_age, j.date_of_attempt as enrollment,k.lw_crf1_09 as woman_nm, k.lw_crf1_10 as husband_nm, concat(l.lw_crf_1_11,l.lw_crf_1_12,l.lw_crf_1_13,l.lw_crf_1_14,l.lw_crf_1_15,l.lw_crf_1_16) as dssid, (select zz.lw_crf4a_24 from form_crf_4a as zz  where zz.lw_crf4a_23=2 and m.study_id=zz.study_id) as DOD from form_crf_3a as i left join form_crf_2 as j on i.assis_id=j.assis_id left join pw as k on k.id=i.assis_id left join dss_address l on k.dss_id=l.dss_id   left join studies as m on m.assis_id=k.id where DATEDIFF(CURDATE(),str_to_date(j.lw_crf2_21, '%d-%m-%Y')) >38 and i.lw_crf_3a_19='c' and l.lw_crf_1_11='" + DropDownList1.SelectedValue + "' and concat(l.lw_crf_1_11,l.lw_crf_1_12,l.lw_crf_1_13,l.lw_crf_1_14,l.lw_crf_1_15,l.lw_crf_1_16) like '%" + txtdssidPending.Text + "%' and not exists (select a.form_crf_5a_id,a.followup_num,a.study_id from form_crf_5a as a where  m.study_id=a.study_id and a.form_crf_5a_id=(SELECT max(z.form_crf_5a_id) from form_crf_5a as z where a.study_id=z.study_id and (z.lw_crf5a_53='1' || z.lw_crf5a_53='2')) group by a.study_id)", con);
                    MySqlDataAdapter sda = new MySqlDataAdapter();
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        DataTable dt = new DataTable();
                        {
                            sda.Fill(dt);
                            GridView2.DataSource = dt;
                            GridView2.DataBind();
                            con.Close();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script type=\"text/javascript\">alert('" + ex.Message + "')</script>");
            }
            finally
            {
                con.Close();
            }
        }




        public void ExcelExportPending()
        {
            try
            {
                Response.Clear();
                Response.AddHeader("content-disposition", "attachment;filename=Azithromycin Pending (" + DateTime.Today.ToString("dd-MM-yyyy") + ").xls");
                Response.Charset = "";

                Response.ContentType = "application/vnd.xls";
                System.IO.StringWriter stringWrite = new System.IO.StringWriter();
                System.Web.UI.HtmlTextWriter htmlWrite =
                new HtmlTextWriter(stringWrite);
                GridView2.AllowPaging = false;

                GridView2.CaptionAlign = TableCaptionAlign.Top;

                ExcelExportP();
                for (int i = 0; i < GridView2.HeaderRow.Cells.Count; i++)
                {
                    GridView2.HeaderRow.Cells[i].Style.Add("background-color", "#5D7B9D");
                    GridView2.HeaderRow.Cells[i].Style.Add("Color", "white");
                }
                GridView2.RenderControl(htmlWrite);
                Response.Write(stringWrite.ToString());
                Response.End();

            }
            catch (Exception ex)
            {
                Response.Write("<script type=\"text/javascript\">alert(" + ex.Message + ")</script>");
            }
        }
























        protected void btnSearchDose_Click(object sender, EventArgs e)
        {
            ShowDataDose();
            txtdssidDose.Focus();
        }








        private void ShowDataDose()
        {
            MySqlConnection con = new MySqlConnection(constr);
            try
            {
                if (DropDownList2.SelectedValue == "0")
                {
                    con.Open();
                    MySqlCommand cmd;
                    cmd = new MySqlCommand("select a.form_crf_5a_id,a.followup_num,a.lw_crf5a_02 as dov, DATEDIFF(str_to_date(a.lw_crf5a_02, '%d-%m-%Y'), str_to_date(h.lw_crf2_21, '%d-%m-%Y')) as age, c.study_code,   d.lw_crf1_09 as woman_nm,  d.lw_crf1_10 as husband_nm,         concat(e.lw_crf_1_11,e.lw_crf_1_12,e.lw_crf_1_13,e.lw_crf_1_14,e.lw_crf_1_15,e.lw_crf_1_16)as dssid,a.lw_crf5a_54a as weight_gram, a.lw_crf5a_54b as weight_kg, a.lw_crf5a_55 as dose_mg,  a.lw_crf5a_56 as dose_ml 		from form_crf_5a as a  left join studies as c on c.study_id=a.study_id left join pw as d on d.id=c.assis_id left join dss_address as e on e.dss_id=d.dss_id    left join form_crf_2 as h on h.assis_id=c.assis_id     where (a.lw_crf5a_53=1 || a.lw_crf5a_53=2) and a.lw_crf5a_54a!=''   and concat(e.lw_crf_1_11,e.lw_crf_1_12,e.lw_crf_1_13,e.lw_crf_1_14,e.lw_crf_1_15,e.lw_crf_1_16) like '%" + txtdssidDose.Text + "%'  group by a.study_id", con);
                    MySqlDataAdapter sda = new MySqlDataAdapter();
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        DataTable dt = new DataTable();
                        {
                            sda.Fill(dt);
                            GridView3.DataSource = dt;
                            GridView3.DataBind();
                            con.Close();
                        }
                    }
                }
                else
                {
                    con.Open();
                    MySqlCommand cmd;
                    cmd = new MySqlCommand("select a.form_crf_5a_id,a.followup_num,a.lw_crf5a_02 as dov, DATEDIFF(str_to_date(a.lw_crf5a_02, '%d-%m-%Y'), str_to_date(h.lw_crf2_21, '%d-%m-%Y')) as age, c.study_code,   d.lw_crf1_09 as woman_nm,  d.lw_crf1_10 as husband_nm,         concat(e.lw_crf_1_11,e.lw_crf_1_12,e.lw_crf_1_13,e.lw_crf_1_14,e.lw_crf_1_15,e.lw_crf_1_16)as dssid,a.lw_crf5a_54a as weight_gram, a.lw_crf5a_54b as weight_kg, a.lw_crf5a_55 as dose_mg,  a.lw_crf5a_56 as dose_ml 		from form_crf_5a as a  left join studies as c on c.study_id=a.study_id left join pw as d on d.id=c.assis_id left join dss_address as e on e.dss_id=d.dss_id    left join form_crf_2 as h on h.assis_id=c.assis_id     where (a.lw_crf5a_53=1 || a.lw_crf5a_53=2) and a.lw_crf5a_54a!=''   and concat(e.lw_crf_1_11,e.lw_crf_1_12,e.lw_crf_1_13,e.lw_crf_1_14,e.lw_crf_1_15,e.lw_crf_1_16) like '%" + txtdssidDose.Text + "%' and e.lw_crf_1_11='" + DropDownList2.SelectedValue + "' group by a.study_id", con);
                    MySqlDataAdapter sda = new MySqlDataAdapter();
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        DataTable dt = new DataTable();
                        {
                            sda.Fill(dt);
                            GridView3.DataSource = dt;
                            GridView3.DataBind();
                            con.Close();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script type=\"text/javascript\">alert('" + ex.Message + "')</script>");
            }
            finally
            {
                con.Close();
            }
        }







        protected void btnExportDose_Click(object sender, EventArgs e)
        {
            ShowDataDose();
            if (GridView3.Rows.Count != 0)
            {
                ExcelExportDose();
            }
            txtdssidDose.Focus();
        }




        private void ExcelExportD()
        {
            MySqlConnection con = new MySqlConnection(constr);
            try
            {
                if (DropDownList2.SelectedValue == "0")
                {
                    con.Open();
                    MySqlCommand cmd;
                    cmd = new MySqlCommand("select a.form_crf_5a_id,a.followup_num,a.lw_crf5a_02 as dov, DATEDIFF(str_to_date(a.lw_crf5a_02, '%d-%m-%Y'), str_to_date(h.lw_crf2_21, '%d-%m-%Y')) as age, c.study_code,   d.lw_crf1_09 as woman_nm,  d.lw_crf1_10 as husband_nm,         concat(e.lw_crf_1_11,e.lw_crf_1_12,e.lw_crf_1_13,e.lw_crf_1_14,e.lw_crf_1_15,e.lw_crf_1_16)as dssid,a.lw_crf5a_54a as weight_gram, a.lw_crf5a_54b as weight_kg, a.lw_crf5a_55 as dose_mg,  a.lw_crf5a_56 as dose_ml 		from form_crf_5a as a  left join studies as c on c.study_id=a.study_id left join pw as d on d.id=c.assis_id left join dss_address as e on e.dss_id=d.dss_id    left join form_crf_2 as h on h.assis_id=c.assis_id     where (a.lw_crf5a_53=1 || a.lw_crf5a_53=2) and a.lw_crf5a_54a!=''   and concat(e.lw_crf_1_11,e.lw_crf_1_12,e.lw_crf_1_13,e.lw_crf_1_14,e.lw_crf_1_15,e.lw_crf_1_16) like '%" + txtdssidDose.Text + "%'  group by a.study_id", con);
                    //cmd = new MySqlCommand("select a.form_crf_5a_id,a.followup_num,a.age,a.study_code,a.lw_crf5a_02 as dov,a.q10 as woman_nm, a.q11 as husband_nm,a.dssid,a.lw_crf5a_54a as weight_gram, a.lw_crf5a_54b as weight_kg, a.lw_crf5a_55 as dose_mg,  a.lw_crf5a_56 as dose_ml from view_crf5a as a where  a.form_crf_5a_id=(SELECT max(z.form_crf_5a_id) from view_crf5a as z where a.study_code=z.study_code and  (z.lw_crf5a_53=1 || z.lw_crf5a_53=2)) and a.dssid like '%" + txtdssidDose.Text + "%'group by a.study_code", con);
                    MySqlDataAdapter sda = new MySqlDataAdapter();
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        DataTable dt = new DataTable();
                        {
                            sda.Fill(dt);
                            GridView4.DataSource = dt;
                            GridView4.DataBind();
                            con.Close();
                        }
                    }
                }
                else
                {
                    con.Open();
                    MySqlCommand cmd;
                    cmd = new MySqlCommand("select a.form_crf_5a_id,a.followup_num,a.lw_crf5a_02 as dov, DATEDIFF(str_to_date(a.lw_crf5a_02, '%d-%m-%Y'), str_to_date(h.lw_crf2_21, '%d-%m-%Y')) as age, c.study_code,   d.lw_crf1_09 as woman_nm,  d.lw_crf1_10 as husband_nm,         concat(e.lw_crf_1_11,e.lw_crf_1_12,e.lw_crf_1_13,e.lw_crf_1_14,e.lw_crf_1_15,e.lw_crf_1_16)as dssid,a.lw_crf5a_54a as weight_gram, a.lw_crf5a_54b as weight_kg, a.lw_crf5a_55 as dose_mg,  a.lw_crf5a_56 as dose_ml 		from form_crf_5a as a  left join studies as c on c.study_id=a.study_id left join pw as d on d.id=c.assis_id left join dss_address as e on e.dss_id=d.dss_id    left join form_crf_2 as h on h.assis_id=c.assis_id     where (a.lw_crf5a_53=1 || a.lw_crf5a_53=2) and a.lw_crf5a_54a!=''   and concat(e.lw_crf_1_11,e.lw_crf_1_12,e.lw_crf_1_13,e.lw_crf_1_14,e.lw_crf_1_15,e.lw_crf_1_16) like '%" + txtdssidDose.Text + "%' and e.lw_crf_1_11='" + DropDownList2.SelectedValue + "' group by a.study_id", con);
                    //cmd = new MySqlCommand("select a.form_crf_5a_id,a.followup_num,a.age,a.study_code,a.lw_crf5a_02 as dov,a.q10 as woman_nm, a.q11 as husband_nm,a.dssid,a.lw_crf5a_54a as weight_gram, a.lw_crf5a_54b as weight_kg, a.lw_crf5a_55 as dose_mg,  a.lw_crf5a_56 as dose_ml from view_crf5a as a where a.form_crf_5a_id=(SELECT max(z.form_crf_5a_id) from view_crf5a as z where a.study_code=z.study_code and  (z.lw_crf5a_53=1 || z.lw_crf5a_53=2)) and a.dssid like '" + DropDownList2.SelectedValue + "%' and a.dssid like '%" + txtdssidDose.Text + "%'group by a.study_code", con);
                    MySqlDataAdapter sda = new MySqlDataAdapter();
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        DataTable dt = new DataTable();
                        {
                            sda.Fill(dt);
                            GridView4.DataSource = dt;
                            GridView4.DataBind();
                            con.Close();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script type=\"text/javascript\">alert('" + ex.Message + "')</script>");
            }
            finally
            {
                con.Close();
            }
        }




        public void ExcelExportDose()
        {
            try
            {
                Response.Clear();
                Response.AddHeader("content-disposition", "attachment;filename=Azithromycin Dose (" + DateTime.Today.ToString("dd-MM-yyyy") + ").xls");
                Response.Charset = "";

                Response.ContentType = "application/vnd.xls";
                System.IO.StringWriter stringWrite = new System.IO.StringWriter();
                System.Web.UI.HtmlTextWriter htmlWrite =
                new HtmlTextWriter(stringWrite);
                GridView4.AllowPaging = false;

                GridView4.CaptionAlign = TableCaptionAlign.Top;

                ExcelExportD();
                for (int i = 0; i < GridView4.HeaderRow.Cells.Count; i++)
                {
                    GridView4.HeaderRow.Cells[i].Style.Add("background-color", "#5D7B9D");
                    GridView4.HeaderRow.Cells[i].Style.Add("Color", "white");
                }
                GridView4.RenderControl(htmlWrite);
                Response.Write(stringWrite.ToString());
                Response.End();

            }
            catch (Exception ex)
            {
                Response.Write("<script type=\"text/javascript\">alert(" + ex.Message + ")</script>");
            }
        }


    }
}