// DXInfo.Ekey.ActiveXPropPage.cpp : CDXInfoEkeyActiveXPropPage 属性页类的实现。

#include "stdafx.h"
#include "DXInfo.Ekey.ActiveX.h"
#include "DXInfo.Ekey.ActiveXPropPage.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#endif


IMPLEMENT_DYNCREATE(CDXInfoEkeyActiveXPropPage, COlePropertyPage)



// 消息映射

BEGIN_MESSAGE_MAP(CDXInfoEkeyActiveXPropPage, COlePropertyPage)
END_MESSAGE_MAP()



// 初始化类工厂和 guid

IMPLEMENT_OLECREATE_EX(CDXInfoEkeyActiveXPropPage, "DXINFOEKEYACTI.DXInfoEkeyActiPropPage.1",
	0x6c4da5e2, 0x77eb, 0x4f4b, 0x88, 0x9, 0xc4, 0xfd, 0x1a, 0xb8, 0xbf, 0xa3)



// CDXInfoEkeyActiveXPropPage::CDXInfoEkeyActiveXPropPageFactory::UpdateRegistry -
// 添加或移除 CDXInfoEkeyActiveXPropPage 的系统注册表项

BOOL CDXInfoEkeyActiveXPropPage::CDXInfoEkeyActiveXPropPageFactory::UpdateRegistry(BOOL bRegister)
{
	if (bRegister)
		return AfxOleRegisterPropertyPageClass(AfxGetInstanceHandle(),
			m_clsid, IDS_DXINFOEKEYACTIVEX_PPG);
	else
		return AfxOleUnregisterClass(m_clsid, NULL);
}



// CDXInfoEkeyActiveXPropPage::CDXInfoEkeyActiveXPropPage - 构造函数

CDXInfoEkeyActiveXPropPage::CDXInfoEkeyActiveXPropPage() :
	COlePropertyPage(IDD, IDS_DXINFOEKEYACTIVEX_PPG_CAPTION)
{
}



// CDXInfoEkeyActiveXPropPage::DoDataExchange - 在页和属性间移动数据

void CDXInfoEkeyActiveXPropPage::DoDataExchange(CDataExchange* pDX)
{
	DDP_PostProcessing(pDX);
}



// CDXInfoEkeyActiveXPropPage 消息处理程序
