#pragma once

// DXInfo.Ekey.ActiveXPropPage.h : CDXInfoEkeyActiveXPropPage ����ҳ���������


// CDXInfoEkeyActiveXPropPage : �й�ʵ�ֵ���Ϣ������� DXInfo.Ekey.ActiveXPropPage.cpp��

class CDXInfoEkeyActiveXPropPage : public COlePropertyPage
{
	DECLARE_DYNCREATE(CDXInfoEkeyActiveXPropPage)
	DECLARE_OLECREATE_EX(CDXInfoEkeyActiveXPropPage)

// ���캯��
public:
	CDXInfoEkeyActiveXPropPage();

// �Ի�������
	enum { IDD = IDD_PROPPAGE_DXINFOEKEYACTIVEX };

// ʵ��
protected:
	virtual void DoDataExchange(CDataExchange* pDX);    // DDX/DDV ֧��

// ��Ϣӳ��
protected:
	DECLARE_MESSAGE_MAP()
};

