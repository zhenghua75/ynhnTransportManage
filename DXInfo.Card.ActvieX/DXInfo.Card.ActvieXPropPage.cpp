// DXInfo.Card.ActvieXPropPage.cpp : CDXInfoCardActvieXPropPage ����ҳ���ʵ�֡�

#include "stdafx.h"
#include "DXInfo.Card.ActvieX.h"
#include "DXInfo.Card.ActvieXPropPage.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#endif


IMPLEMENT_DYNCREATE(CDXInfoCardActvieXPropPage, COlePropertyPage)



// ��Ϣӳ��

BEGIN_MESSAGE_MAP(CDXInfoCardActvieXPropPage, COlePropertyPage)
END_MESSAGE_MAP()



// ��ʼ���๤���� guid

IMPLEMENT_OLECREATE_EX(CDXInfoCardActvieXPropPage, "DXINFOCARDACTV.DXInfoCardActvPropPage.1",
	0x16e5318f, 0x96f0, 0x4fd5, 0xa7, 0x8d, 0x9f, 0x25, 0xae, 0x7c, 0x29, 0xdf)



// CDXInfoCardActvieXPropPage::CDXInfoCardActvieXPropPageFactory::UpdateRegistry -
// ��ӻ��Ƴ� CDXInfoCardActvieXPropPage ��ϵͳע�����

BOOL CDXInfoCardActvieXPropPage::CDXInfoCardActvieXPropPageFactory::UpdateRegistry(BOOL bRegister)
{
	if (bRegister)
		return AfxOleRegisterPropertyPageClass(AfxGetInstanceHandle(),
			m_clsid, IDS_DXINFOCARDACTVIEX_PPG);
	else
		return AfxOleUnregisterClass(m_clsid, NULL);
}



// CDXInfoCardActvieXPropPage::CDXInfoCardActvieXPropPage - ���캯��

CDXInfoCardActvieXPropPage::CDXInfoCardActvieXPropPage() :
	COlePropertyPage(IDD, IDS_DXINFOCARDACTVIEX_PPG_CAPTION)
{
}



// CDXInfoCardActvieXPropPage::DoDataExchange - ��ҳ�����Լ��ƶ�����

void CDXInfoCardActvieXPropPage::DoDataExchange(CDataExchange* pDX)
{
	DDP_PostProcessing(pDX);
}



// CDXInfoCardActvieXPropPage ��Ϣ�������
