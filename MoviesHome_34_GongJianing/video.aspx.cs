﻿using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class video : System.Web.UI.Page
{
    public string url = "";
    //public string name = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string id = System.Web.HttpContext.Current.Request.QueryString["id"];
            string sql = "select id,url from movielist where id =" + id + "";
            DataSet ds = DBHelper.sqlMethod(sql);

            int cnt = ds.Tables[0].Rows.Count;
            if (0 == cnt)
            {
                Response.Redirect("index.aspx");
            }
            else {
                //name = ds.Tables[0].Rows[i]["mname"].ToString();
                url = ds.Tables[0].Rows[0]["url"].ToString();
                hitAdd(id);
            }
            
            
            
        }
    }

    private void hitAdd(string id)
    {
        string sql = "update movielist set playtimes = playtimes +1 where id=" + id;
        DBHelper.exeDML(sql);
    }
}
