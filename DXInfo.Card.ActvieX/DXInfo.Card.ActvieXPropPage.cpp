// DXInfo.Card.ActvieXPropPage.cpp : CDXInfoCardActvieXPropPage 属性页类的实现。

#include "stdafx.h"
#include "DXInfo.Card.ActvieX.h"
#include "DXInfo.Card.ActvieXPropPage.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#endif


IMPLEMENT_DYNCREATE(CDXInfoCardActvieXPropPage, COlePropertyPage)



// 消息映射

BEGIN_MESSAGE_MAP(CDXInfoCardActvieXPropPage, COlePropertyPage)
END_MESSAGE_MAP()



// 初始化类工厂和 guid

IMPLEMENT_OLECREATE_EX(CDXInfoCardActvieXPropPage, "DXINFOCARDACTV.DXInfoCardActvPropPage.1",
	0x16e5318f, 0x96f0, 0x4fd5, 0xa7, 0x8d, 0x9f, 0x25, 0xae, 0x7c, 0x29, 0xdf)



// CDXInfoCardActvieXPropPage::CDXInfoCardActvieXPropPageFactory::UpdateRegistry -
// 添加或移除 CDXInfoCardActvieXPropPage 的系统注册表项

BOOL CDXInfoCardActvieXPropPage::CDXInfoCardActvieXPropPageFactory::UpdateRegistry(BOOL bRegister)
{
	if (bRegister)
		return AfxOleRegisterPropertyPageClass(AfxGetInstanceHandle(),
			m_clsid, IDS_DXINFOCARDACTVIEX_PPG);
	else
		return AfxOleUnregisterClass(m_clsid, NULL);
}



// CDXInfoCardActvieXPropPage::CDXInfoCardActvieXPropPage - 构造函数

CDXInfoCardActvieXPropPage::CDXInfoCardActvieXPropPage() :
	COlePropertyPage(IDD, IDS_DXINFOCARDACTVIEX_PPG_CAPTION)
{
}



// CDXInfoCardActvieXPropPage::DoDataExchange - 在页和属性间移动数据

void CDXInfoCardActvieXPropPage::DoDataExchange(CDataExchange* pDX)
{
	DDP_PostProcessing(pDX);
}



// CDXInfoCardActvieXPropPage 消息处理程序
