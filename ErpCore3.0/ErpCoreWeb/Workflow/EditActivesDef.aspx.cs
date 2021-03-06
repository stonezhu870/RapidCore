﻿using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Reflection;
using ErpCoreModel;
using ErpCoreModel.Base;
using ErpCoreModel.Framework;
using ErpCoreModel.Workflow;

public partial class Workflow_EditActivesDef : System.Web.UI.Page
{
    public CTable m_Table = null;
    public CWorkflowDef m_WorkflowDef = null;
    public CActivesDefMgr m_ActivesDefMgr = null;
    public CBaseObject m_BaseObject = null;
    public CCompany m_Company = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["User"] == null)
        {
            Response.Redirect("../Login.aspx");
            Response.End();
        }

        string B_Company_id = Request["B_Company_id"];
        if (string.IsNullOrEmpty(B_Company_id))
            m_Company = Global.GetCtx(Session["TopCompany"].ToString()).CompanyMgr.FindTopCompany();
        else
            m_Company = (CCompany)Global.GetCtx(Session["TopCompany"].ToString()).CompanyMgr.Find(new Guid(B_Company_id));

        string wfid = Request["wfid"];
        if (string.IsNullOrEmpty(wfid))
        {
            Response.End();
            return;
        }
        m_WorkflowDef = (CWorkflowDef)m_Company.WorkflowDefMgr.Find(new Guid(wfid));
        if (m_WorkflowDef == null) //可能是新建的
        {
            if (Session["AddWorkflowDef"] == null)
            {
                Response.End();
                return;
            }
            m_WorkflowDef = (CWorkflowDef)Session["AddWorkflowDef"];
        }
        m_ActivesDefMgr = (CActivesDefMgr)m_WorkflowDef.ActivesDefMgr;

        string id = Request["id"];
        if (string.IsNullOrEmpty(id))
        {
            Response.End();
            return;
        }
        m_BaseObject = m_ActivesDefMgr.Find(new Guid(id));
        if (m_BaseObject == null)
        {
            Response.End();
            return;
        }

        m_Table = m_ActivesDefMgr.Table;


        if (Request.Params["Action"] == "Cancel")
        {
            m_BaseObject.Cancel();
            Response.End();
        }
        else if (Request.Params["Action"] == "PostData")
        {
            PostData();
            Response.End();
        }
    }
    void PostData()
    {
        List<CBaseObject> lstCol = m_Table.ColumnMgr.GetList();
        bool bHasVisible = false;
        foreach (CBaseObject obj in lstCol)
        {
            CColumn col = (CColumn)obj;

            if (col.Code.Equals("id", StringComparison.OrdinalIgnoreCase))
                continue;
            else if (col.Code.Equals("Created", StringComparison.OrdinalIgnoreCase))
                continue;
            else if (col.Code.Equals("Creator", StringComparison.OrdinalIgnoreCase))
            {
                //BaseObject.SetColValue(col, Program.User.Id);
                continue;
            }
            else if (col.Code.Equals("Updated", StringComparison.OrdinalIgnoreCase))
                continue;
            else if (col.Code.Equals("Updator", StringComparison.OrdinalIgnoreCase))
            {
                //BaseObject.SetColValue(col, Program.User.Id);
                continue;
            }

            m_BaseObject.SetColValue(col, Request.Params[col.Code]);
            bHasVisible = true;
        }
        if (!bHasVisible)
        {
            Response.Write("没有可修改字段！");
            return;
        }
        CUser user = (CUser)Session["User"];
        m_BaseObject.Updator = user.Id;
        m_ActivesDefMgr.Update(m_BaseObject);
    }
}
