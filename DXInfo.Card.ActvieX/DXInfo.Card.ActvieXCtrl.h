#pragma once

// DXInfo.Card.ActvieXCtrl.h : CDXInfoCardActvieXCtrl ActiveX �ؼ����������


// CDXInfoCardActvieXCtrl : �й�ʵ�ֵ���Ϣ������� DXInfo.Card.ActvieXCtrl.cpp��

class CDXInfoCardActvieXCtrl : public COleControl
{
	DECLARE_DYNCREATE(CDXInfoCardActvieXCtrl)

// ���캯��
public:
	CDXInfoCardActvieXCtrl();

// ��д
public:
	virtual void OnDraw(CDC* pdc, const CRect& rcBounds, const CRect& rcInvalid);
	virtual void DoPropExchange(CPropExchange* pPX);
	virtual void OnResetState();

// ʵ��
protected:
	~CDXInfoCardActvieXCtrl();

	DECLARE_OLECREATE_EX(CDXInfoCardActvieXCtrl)    // �๤���� guid
	DECLARE_OLETYPELIB(CDXInfoCardActvieXCtrl)      // GetTypeInfo
	DECLARE_PROPPAGEIDS(CDXInfoCardActvieXCtrl)     // ����ҳ ID
	DECLARE_OLECTLTYPE(CDXInfoCardActvieXCtrl)		// �������ƺ�����״̬

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
		dispidRecycleCard = 4L,
		dispidWrite = 3L,
		dispidPutCard = 2L,
		dispidReadCard = 1L
	};
protected:
	BSTR ReadCard(void);
	VARIANT_BOOL PutCard(LPCTSTR data);
	VARIANT_BOOL Write(LPCTSTR data);
	VARIANT_BOOL RecycleCard(void);
};

