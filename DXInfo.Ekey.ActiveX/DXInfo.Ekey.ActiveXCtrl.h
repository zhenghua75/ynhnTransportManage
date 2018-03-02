#pragma once

// DXInfo.Ekey.ActiveXCtrl.h : CDXInfoEkeyActiveXCtrl ActiveX �ؼ����������


// CDXInfoEkeyActiveXCtrl : �й�ʵ�ֵ���Ϣ������� DXInfo.Ekey.ActiveXCtrl.cpp��

class CDXInfoEkeyActiveXCtrl : public COleControl
{
	DECLARE_DYNCREATE(CDXInfoEkeyActiveXCtrl)

// ���캯��
public:
	CDXInfoEkeyActiveXCtrl();

// ��д
public:
	virtual void OnDraw(CDC* pdc, const CRect& rcBounds, const CRect& rcInvalid);
	virtual void DoPropExchange(CPropExchange* pPX);
	virtual void OnResetState();

// ʵ��
protected:
	~CDXInfoEkeyActiveXCtrl();

	DECLARE_OLECREATE_EX(CDXInfoEkeyActiveXCtrl)    // �๤���� guid
	DECLARE_OLETYPELIB(CDXInfoEkeyActiveXCtrl)      // GetTypeInfo
	DECLARE_PROPPAGEIDS(CDXInfoEkeyActiveXCtrl)     // ����ҳ ID
	DECLARE_OLECTLTYPE(CDXInfoEkeyActiveXCtrl)		// �������ƺ�����״̬

// ��Ϣӳ��
	DECLARE_MESSAGE_MAP()

// ����ӳ��
	DECLARE_DISPATCH_MAP()

	afx_msg void AboutBox();

// �¼�ӳ��
	DECLARE_EVENT_MAP()

// ���Ⱥ��¼� ID
public:
	enum {
		dispidGetHardwareID = 2L,
		dispidVerify = 1L
	};
protected:
	VARIANT_BOOL Verify(void);
	BSTR GetHardwareID(void);
};

