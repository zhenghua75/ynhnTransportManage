// DXInfo.Ekey.ActiveXPropPage.cpp : CDXInfoEkeyActiveXPropPage ����ҳ���ʵ�֡�

#include "stdafx.h"
#include "DXInfo.Ekey.ActiveX.h"
#include "DXInfo.Ekey.ActiveXPropPage.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#endif


IMPLEMENT_DYNCREATE(CDXInfoEkeyActiveXPropPage, COlePropertyPage)



// ��Ϣӳ��

BEGIN_MESSAGE_MAP(CDXInfoEkeyActiveXPropPage, COlePropertyPage)
END_MESSAGE_MAP()



// ��ʼ���๤���� guid

IMPLEMENT_OLECREATE_EX(CDXInfoEkeyActiveXPropPage, "DXINFOEKEYACTI.DXInfoEkeyActiPropPage.1",
	0x6c4da5e2, 0x77eb, 0x4f4b, 0x88, 0x9, 0xc4, 0xfd, 0x1a, 0xb8, 0xbf, 0xa3)



// CDXInfoEkeyActiveXPropPage::CDXInfoEkeyActiveXPropPageFactory::UpdateRegistry -
// ��ӻ��Ƴ� CDXInfoEkeyActiveXPropPage ��ϵͳע�����

BOOL CDXInfoEkeyActiveXPropPage::CDXInfoEkeyActiveXPropPageFactory::UpdateRegistry(BOOL bRegister)
{
	if (bRegister)
		return AfxOleRegisterPropertyPageClass(AfxGetInstanceHandle(),
			m_clsid, IDS_DXINFOEKEYACTIVEX_PPG);
	else
		return AfxOleUnregisterClass(m_clsid, NULL);
}



// CDXInfoEkeyActiveXPropPage::CDXInfoEkeyActiveXPropPage - ���캯��

CDXInfoEkeyActiveXPropPage::CDXInfoEkeyActiveXPropPage() :
	COlePropertyPage(IDD, IDS_DXINFOEKEYACTIVEX_PPG_CAPTION)
{
}



// CDXInfoEkeyActiveXPropPage::DoDataExchange - ��ҳ�����Լ��ƶ�����

void CDXInfoEkeyActiveXPropPage::DoDataExchange(CDataExchange* pDX)
{
	DDP_PostProcessing(pDX);
}



// CDXInfoEkeyActiveXPropPage ��Ϣ�������
