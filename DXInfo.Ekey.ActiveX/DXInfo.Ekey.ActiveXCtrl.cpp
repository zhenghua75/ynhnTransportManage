// DXInfo.Ekey.ActiveXCtrl.cpp : CDXInfoEkeyActiveXCtrl ActiveX 控件类的实现。

#include "stdafx.h"
#include "DXInfo.Ekey.ActiveX.h"
#include "DXInfo.Ekey.ActiveXCtrl.h"
#include "DXInfo.Ekey.ActiveXPropPage.h"
#include "afxdialogex.h"

#include "DXInfo.Ekey.h"
#include "NT77Api.h"
#ifdef _DEBUG
#define new DEBUG_NEW
#endif


IMPLEMENT_DYNCREATE(CDXInfoEkeyActiveXCtrl, COleControl)



// 消息映射

BEGIN_MESSAGE_MAP(CDXInfoEkeyActiveXCtrl, COleControl)
	ON_OLEVERB(AFX_IDS_VERB_PROPERTIES, OnProperties)
END_MESSAGE_MAP()



// 调度映射

BEGIN_DISPATCH_MAP(CDXInfoEkeyActiveXCtrl, COleControl)
	DISP_FUNCTION_ID(CDXInfoEkeyActiveXCtrl, "AboutBox", DISPID_ABOUTBOX, AboutBox, VT_EMPTY, VTS_NONE)
	DISP_FUNCTION_ID(CDXInfoEkeyActiveXCtrl, "Verify", dispidVerify, Verify, VT_BOOL, VTS_NONE)
	DISP_FUNCTION_ID(CDXInfoEkeyActiveXCtrl, "GetHardwareID", dispidGetHardwareID, GetHardwareID, VT_BSTR, VTS_NONE)
END_DISPATCH_MAP()



// 事件映射

BEGIN_EVENT_MAP(CDXInfoEkeyActiveXCtrl, COleControl)
END_EVENT_MAP()



// 属性页

// TODO: 按需要添加更多属性页。请记住增加计数!
BEGIN_PROPPAGEIDS(CDXInfoEkeyActiveXCtrl, 1)
	PROPPAGEID(CDXInfoEkeyActiveXPropPage::guid)
END_PROPPAGEIDS(CDXInfoEkeyActiveXCtrl)



// 初始化类工厂和 guid

IMPLEMENT_OLECREATE_EX(CDXInfoEkeyActiveXCtrl, "DXINFOEKEYACTIVE.DXInfoEkeyActiveCtrl.1",
	0x5790c5f1, 0xaaf8, 0x4e72, 0xbd, 0xe7, 0x86, 0x5, 0xa5, 0, 0xa, 0xd4)



// 键入库 ID 和版本

IMPLEMENT_OLETYPELIB(CDXInfoEkeyActiveXCtrl, _tlid, _wVerMajor, _wVerMinor)



// 接口 ID

const IID IID_DDXInfoEkeyActiveX = { 0x42E5B082, 0xDE9, 0x437B, { 0xBB, 0xF3, 0xF7, 0x79, 0xDE, 0xA9, 0x9A, 0x33 } };
const IID IID_DDXInfoEkeyActiveXEvents = { 0xC719E07A, 0x1214, 0x4536, { 0xB7, 0x17, 0x25, 0xE3, 0xC2, 0xEC, 0xBF, 0x91 } };


// 控件类型信息

static const DWORD _dwDXInfoEkeyActiveXOleMisc =
	OLEMISC_INVISIBLEATRUNTIME |
	OLEMISC_ACTIVATEWHENVISIBLE |
	OLEMISC_SETCLIENTSITEFIRST |
	OLEMISC_INSIDEOUT |
	OLEMISC_CANTLINKINSIDE |
	OLEMISC_RECOMPOSEONRESIZE;

IMPLEMENT_OLECTLTYPE(CDXInfoEkeyActiveXCtrl, IDS_DXINFOEKEYACTIVEX, _dwDXInfoEkeyActiveXOleMisc)



// CDXInfoEkeyActiveXCtrl::CDXInfoEkeyActiveXCtrlFactory::UpdateRegistry -
// 添加或移除 CDXInfoEkeyActiveXCtrl 的系统注册表项

BOOL CDXInfoEkeyActiveXCtrl::CDXInfoEkeyActiveXCtrlFactory::UpdateRegistry(BOOL bRegister)
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
			IDS_DXINFOEKEYACTIVEX,
			IDB_DXINFOEKEYACTIVEX,
			afxRegApartmentThreading,
			_dwDXInfoEkeyActiveXOleMisc,
			_tlid,
			_wVerMajor,
			_wVerMinor);
	else
		return AfxOleUnregisterClass(m_clsid, m_lpszProgID);
}



// CDXInfoEkeyActiveXCtrl::CDXInfoEkeyActiveXCtrl - 构造函数

CDXInfoEkeyActiveXCtrl::CDXInfoEkeyActiveXCtrl()
{
	InitializeIIDs(&IID_DDXInfoEkeyActiveX, &IID_DDXInfoEkeyActiveXEvents);
	// TODO: 在此初始化控件的实例数据。
}



// CDXInfoEkeyActiveXCtrl::~CDXInfoEkeyActiveXCtrl - 析构函数

CDXInfoEkeyActiveXCtrl::~CDXInfoEkeyActiveXCtrl()
{
	// TODO: 在此清理控件的实例数据。
}



// CDXInfoEkeyActiveXCtrl::OnDraw - 绘图函数

void CDXInfoEkeyActiveXCtrl::OnDraw(
			CDC* pdc, const CRect& rcBounds, const CRect& rcInvalid)
{
	if (!pdc)
		return;

	// TODO: 用您自己的绘图代码替换下面的代码。
	pdc->FillRect(rcBounds, CBrush::FromHandle((HBRUSH)GetStockObject(WHITE_BRUSH)));
	pdc->Ellipse(rcBounds);
}



// CDXInfoEkeyActiveXCtrl::DoPropExchange - 持久性支持

void CDXInfoEkeyActiveXCtrl::DoPropExchange(CPropExchange* pPX)
{
	ExchangeVersion(pPX, MAKELONG(_wVerMinor, _wVerMajor));
	COleControl::DoPropExchange(pPX);

	// TODO: 为每个持久的自定义属性调用 PX_ 函数。
}



// CDXInfoEkeyActiveXCtrl::OnResetState - 将控件重置为默认状态

void CDXInfoEkeyActiveXCtrl::OnResetState()
{
	COleControl::OnResetState();  // 重置 DoPropExchange 中找到的默认值

	// TODO: 在此重置任意其他控件状态。
}



// CDXInfoEkeyActiveXCtrl::AboutBox - 向用户显示“关于”框

void CDXInfoEkeyActiveXCtrl::AboutBox()
{
	CDialogEx dlgAbout(IDD_ABOUTBOX_DXINFOEKEYACTIVEX);
	dlgAbout.DoModal();
}



// CDXInfoEkeyActiveXCtrl 消息处理程序


VARIANT_BOOL CDXInfoEkeyActiveXCtrl::Verify(void)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());

	// TODO: 在此添加调度处理程序代码
	CString appName("ynhnTransport");
	//CString password("5d77a67b65d59b5ceec9a7e3cc068e6c");
	CString password("1a5ce5b0315c1a63937684df3253f73a");
	CDXInfoEkey key(appName,password);
	return key.Verify();
}


BSTR CDXInfoEkeyActiveXCtrl::GetHardwareID(void)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());

	CString strResult;

	// TODO: 在此添加调度处理程序代码
	CString appName("ynhnTransport");
	//CString password("5d77a67b65d59b5ceec9a7e3cc068e6c");
	CString password("1a5ce5b0315c1a63937684df3253f73a");
	CDXInfoEkey key(appName,password);
	char hardwareID[64];
	key.GetHardwareID(hardwareID);
	strResult=hardwareID;
	return strResult.AllocSysString();
}
