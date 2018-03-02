// DXInfo.Card.ActvieXCtrl.cpp : CDXInfoCardActvieXCtrl ActiveX 控件类的实现。

#include "stdafx.h"
#include "DXInfo.Card.ActvieX.h"
#include "DXInfo.Card.ActvieXCtrl.h"
#include "DXInfo.Card.ActvieXPropPage.h"
#include "afxdialogex.h"
#include "DXInfo.Card.h"
//#include "mwrf32.h"
#ifdef _DEBUG
#define new DEBUG_NEW
#endif


IMPLEMENT_DYNCREATE(CDXInfoCardActvieXCtrl, COleControl)



// 消息映射

BEGIN_MESSAGE_MAP(CDXInfoCardActvieXCtrl, COleControl)
	ON_OLEVERB(AFX_IDS_VERB_PROPERTIES, OnProperties)
END_MESSAGE_MAP()



// 调度映射

BEGIN_DISPATCH_MAP(CDXInfoCardActvieXCtrl, COleControl)
	DISP_FUNCTION_ID(CDXInfoCardActvieXCtrl, "AboutBox", DISPID_ABOUTBOX, AboutBox, VT_EMPTY, VTS_NONE)
	DISP_FUNCTION_ID(CDXInfoCardActvieXCtrl, "ReadCard", dispidReadCard, ReadCard, VT_BSTR, VTS_NONE)
	DISP_FUNCTION_ID(CDXInfoCardActvieXCtrl, "PutCard", dispidPutCard, PutCard, VT_BOOL, VTS_BSTR)
	DISP_FUNCTION_ID(CDXInfoCardActvieXCtrl, "Write", dispidWrite, Write, VT_BOOL, VTS_BSTR)
	DISP_FUNCTION_ID(CDXInfoCardActvieXCtrl, "RecycleCard", dispidRecycleCard, RecycleCard, VT_BOOL, VTS_NONE)
END_DISPATCH_MAP()



// 事件映射

BEGIN_EVENT_MAP(CDXInfoCardActvieXCtrl, COleControl)
END_EVENT_MAP()



// 属性页

// TODO: 按需要添加更多属性页。请记住增加计数!
BEGIN_PROPPAGEIDS(CDXInfoCardActvieXCtrl, 1)
	PROPPAGEID(CDXInfoCardActvieXPropPage::guid)
END_PROPPAGEIDS(CDXInfoCardActvieXCtrl)



// 初始化类工厂和 guid

IMPLEMENT_OLECREATE_EX(CDXInfoCardActvieXCtrl, "DXINFOCARDACTVIE.DXInfoCardActvieCtrl.1",
	0x43246d5d, 0x8e72, 0x43c9, 0xba, 0xb1, 0xee, 0x73, 0x3c, 0x3d, 0xdc, 0xa4)



// 键入库 ID 和版本

IMPLEMENT_OLETYPELIB(CDXInfoCardActvieXCtrl, _tlid, _wVerMajor, _wVerMinor)



// 接口 ID

const IID IID_DDXInfoCardActvieX = { 0x4E12BC45, 0xD49E, 0x400D, { 0x86, 0xFA, 0xDE, 0x5D, 0x29, 0x13, 0x2B, 0xF1 } };
const IID IID_DDXInfoCardActvieXEvents = { 0xBAB78D8C, 0x29BA, 0x4661, { 0xB1, 0xA4, 0x91, 0x51, 0x72, 0x76, 0x41, 0x7D } };


// 控件类型信息

static const DWORD _dwDXInfoCardActvieXOleMisc =
	OLEMISC_INVISIBLEATRUNTIME |
	OLEMISC_ACTIVATEWHENVISIBLE |
	OLEMISC_SETCLIENTSITEFIRST |
	OLEMISC_INSIDEOUT |
	OLEMISC_CANTLINKINSIDE |
	OLEMISC_RECOMPOSEONRESIZE;

IMPLEMENT_OLECTLTYPE(CDXInfoCardActvieXCtrl, IDS_DXINFOCARDACTVIEX, _dwDXInfoCardActvieXOleMisc)



// CDXInfoCardActvieXCtrl::CDXInfoCardActvieXCtrlFactory::UpdateRegistry -
// 添加或移除 CDXInfoCardActvieXCtrl 的系统注册表项

BOOL CDXInfoCardActvieXCtrl::CDXInfoCardActvieXCtrlFactory::UpdateRegistry(BOOL bRegister)
{
	// TODO: 验证您的控件是否符合单元模型线程处理规则。
	// 有关更多信息，请参考 MFC 技术说明 64。
	// 如果您的控件不符合单元模型规则，则
	// 必须修改如下代码，将第六个参数从
	// afxRegApartmentThreading 改为 0。

	if (bRegister)
		return AfxOleRegisterControlClass(
			AfxGetInstanceHandle(),
			m_clsid,
			m_lpszProgID,
			IDS_DXINFOCARDACTVIEX,
			IDB_DXINFOCARDACTVIEX,
			afxRegApartmentThreading,
			_dwDXInfoCardActvieXOleMisc,
			_tlid,
			_wVerMajor,
			_wVerMinor);
	else
		return AfxOleUnregisterClass(m_clsid, m_lpszProgID);
}



// CDXInfoCardActvieXCtrl::CDXInfoCardActvieXCtrl - 构造函数

CDXInfoCardActvieXCtrl::CDXInfoCardActvieXCtrl()
{
	InitializeIIDs(&IID_DDXInfoCardActvieX, &IID_DDXInfoCardActvieXEvents);
	// TODO: 在此初始化控件的实例数据。
}



// CDXInfoCardActvieXCtrl::~CDXInfoCardActvieXCtrl - 析构函数

CDXInfoCardActvieXCtrl::~CDXInfoCardActvieXCtrl()
{
	// TODO: 在此清理控件的实例数据。
}



// CDXInfoCardActvieXCtrl::OnDraw - 绘图函数

void CDXInfoCardActvieXCtrl::OnDraw(
			CDC* pdc, const CRect& rcBounds, const CRect& rcInvalid)
{
	if (!pdc)
		return;

	// TODO: 用您自己的绘图代码替换下面的代码。
	pdc->FillRect(rcBounds, CBrush::FromHandle((HBRUSH)GetStockObject(WHITE_BRUSH)));
	pdc->Ellipse(rcBounds);
}



// CDXInfoCardActvieXCtrl::DoPropExchange - 持久性支持

void CDXInfoCardActvieXCtrl::DoPropExchange(CPropExchange* pPX)
{
	ExchangeVersion(pPX, MAKELONG(_wVerMinor, _wVerMajor));
	COleControl::DoPropExchange(pPX);

	// TODO: 为每个持久的自定义属性调用 PX_ 函数。
}



// CDXInfoCardActvieXCtrl::OnResetState - 将控件重置为默认状态

void CDXInfoCardActvieXCtrl::OnResetState()
{
	COleControl::OnResetState();  // 重置 DoPropExchange 中找到的默认值

	// TODO: 在此重置任意其他控件状态。
}



// CDXInfoCardActvieXCtrl::AboutBox - 向用户显示“关于”框

void CDXInfoCardActvieXCtrl::AboutBox()
{
	CDialogEx dlgAbout(IDD_ABOUTBOX_DXINFOCARDACTVIEX);
	dlgAbout.DoModal();
}


BSTR CDXInfoCardActvieXCtrl::ReadCard(void)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());

	CString strResult;
	
	// TODO: 在此添加调度处理程序代码
	unsigned char data[33];
	CString akey("zhenghualhg");
	CString bkey("luohuaigzhh");
	CString akey_old("A3D4C68CD9E5");
	CString bkey_old("B01B4C49A3D3");
	CDXInfoCard card(akey,bkey,akey_old,bkey_old);
	if(card.ReadCard(data))
		strResult.Format("%s",data);
	else
		strResult="";
	return strResult.AllocSysString();
}



VARIANT_BOOL CDXInfoCardActvieXCtrl::PutCard(LPCTSTR data)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());

	// TODO: 在此添加调度处理程序代码
	CString akey("zhenghualhg");
	CString bkey("luohuaigzhh");
	/*CString akey_old("FFFFFFFFFFFF");
	CString bkey_old("FFFFFFFFFFFF");*/
	CString akey_old("A3D4C68CD9E5");
	CString bkey_old("C03F5591EB08");
	CDXInfoCard card(akey,bkey,akey_old,bkey_old);
	if(card.PutCard((unsigned char*)data))
		return VARIANT_TRUE;
	else
		return VARIANT_FALSE;
}


VARIANT_BOOL CDXInfoCardActvieXCtrl::Write(LPCTSTR data)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());

	// TODO: 在此添加调度处理程序代码

	return VARIANT_TRUE;
}


VARIANT_BOOL CDXInfoCardActvieXCtrl::RecycleCard(void)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());

	// TODO: 在此添加调度处理程序代码

	CString akey("zhenghualhg");
	CString bkey("luohuaigzhh");
	/*CString akey_old("FFFFFFFFFFFF");
	CString bkey_old("FFFFFFFFFFFF");*/
	CString akey_old("A3D4C68CD9E5");
	CString bkey_old("C03F5591EB08");
	CDXInfoCard card(akey,bkey,akey_old,bkey_old);
	if(card.RecycleCard())
		return VARIANT_TRUE;
	else
		return VARIANT_FALSE;
}
