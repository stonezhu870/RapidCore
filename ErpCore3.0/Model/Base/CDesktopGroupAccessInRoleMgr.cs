// File:    CAccessInOrgMgr.cs
// Author:  甘孝俭
// email:   ganxiaojian@hotmail.com 
// QQ:      154986287
// http://www.8088net.com
// 协议声明：本软件为开源系统，遵循国际开源组织协议。任何单位或个人可以使用或修改本软件源码，
//          可以用于作为非商业或商业用途，但由于使用本源码所引起的一切后果与作者无关。
//          未经作者许可，禁止任何企业或个人直接出售本源码或者把本软件作为独立的功能进行销售活动，
//          作者将保留追究责任的权利。
// Created: 2011年7月9日 13:43:37
// Purpose: Definition of Class CAccessInOrgMgr

using System;
using System.Text;
using System.Collections.Generic;
using ErpCoreModel.Framework;

namespace ErpCoreModel.Base
{

    public class CDesktopGroupAccessInRoleMgr : CBaseObjectMgr
    {

        public CDesktopGroupAccessInRoleMgr()
        {
            TbCode = "B_DesktopGroupAccessInRole";
            ClassName = "ErpCoreModel.Base.CDesktopGroupAccessInRole";
        }
        public CDesktopGroupAccessInRole FindByDesktopGroup(Guid UI_DesktopGroup_id)
        {
            List<CBaseObject> lstObj = GetList();
            foreach (CBaseObject obj in lstObj)
            {
                CDesktopGroupAccessInRole dgair = (CDesktopGroupAccessInRole)obj;
                if (dgair.UI_DesktopGroup_id == UI_DesktopGroup_id)
                    return dgair;
            }
            return null;
        }
    }
}