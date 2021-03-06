// File:    CAccountDetail.cs
// Author:  甘孝俭
// email:   ganxiaojian@hotmail.com 
// QQ:      154986287
// http://www.8088net.com
// 协议声明：本软件为开源系统，遵循国际开源组织协议。任何单位或个人可以使用或修改本软件源码，
//          可以用于作为非商业或商业用途，但由于使用本源码所引起的一切后果与作者无关。
//          未经作者许可，禁止任何企业或个人直接出售本源码或者把本软件作为独立的功能进行销售活动，
//          作者将保留追究责任的权利。
// Created: 2012/11/28 21:13:40
// Purpose: Definition of Class CAccountDetail

using System;
using System.Text;
using ErpCoreModel.Framework;

namespace ErpCoreModel.Store
{
    
    public class CAccountDetail : CBaseObject
    {

        public CAccountDetail()
        {
            TbCode = "KH_AccountDetail";
            ClassName = "ErpCoreModel.Store.CAccountDetail";

        }

        
        public double Score
        {
            get
            {
                if (m_arrNewVal.ContainsKey("score"))
                    return m_arrNewVal["score"].DoubleVal;
                else
                    return 0;
            }
            set
            {
                if (m_arrNewVal.ContainsKey("score"))
                    m_arrNewVal["score"].DoubleVal = value;
                else
                {
                    CValue val = new CValue();
                    val.DoubleVal = value;
                    m_arrNewVal.Add("score", val);
                }
            }
        }
        public string Content
        {
            get
            {
                if (m_arrNewVal.ContainsKey("content"))
                    return m_arrNewVal["content"].StrVal;
                else
                    return "";
            }
            set
            {
                if (m_arrNewVal.ContainsKey("content"))
                    m_arrNewVal["content"].StrVal = value;
                else
                {
                    CValue val = new CValue();
                    val.StrVal = value;
                    m_arrNewVal.Add("content", val);
                }
            }
        }
        public Guid KH_Account_id
        {
            get
            {
                if (m_arrNewVal.ContainsKey("kh_account_id"))
                    return m_arrNewVal["kh_account_id"].GuidVal;
                else
                    return Guid.Empty;
            }
            set
            {        
                if (m_arrNewVal.ContainsKey("kh_account_id"))
                    m_arrNewVal["kh_account_id"].GuidVal = value;
                else
                {
                    CValue val = new CValue();
                    val.GuidVal = value;
                    m_arrNewVal.Add("kh_account_id", val);
                }
            }
        }
    }
}