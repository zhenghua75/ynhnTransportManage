#pragma once

// DXInfo.Card.ActvieXPropPage.h : CDXInfoCardActvieXPropPage ����ҳ���������


// CDXInfoCardActvieXPropPage : �й�ʵ�ֵ���Ϣ������� DXInfo.Card.ActvieXPropPage.cpp��

class CDXInfoCardActvieXPropPage : public COlePropertyPage
{
	DECLARE_DYNCREATE(CDXInfoCardActvieXPropPage)
	DECLARE_OLECREATE_EX(CDXInfoCardActvieXPropPage)

// ���캯��
public:
	CDXInfoCardActvieXPropPage();

// �Ի�������
	enum { IDD = IDD_PROPPAGE_DXINFOCARDACTVIEX };

// ʵ��
protected:
	virtual void DoDataExchange(CDataExchange* pDX);    // DDX/DDV ֧��

// ��Ϣӳ��
protected:
	DECLARE_MESSAGE_MAP()
};

