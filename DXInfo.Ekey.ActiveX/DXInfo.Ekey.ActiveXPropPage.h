#pragma once

// DXInfo.Ekey.ActiveXPropPage.h : CDXInfoEkeyActiveXPropPage 属性页类的声明。


// CDXInfoEkeyActiveXPropPage : 有关实现的信息，请参阅 DXInfo.Ekey.ActiveXPropPage.cpp。

class CDXInfoEkeyActiveXPropPage : public COlePropertyPage
{
	DECLARE_DYNCREATE(CDXInfoEkeyActiveXPropPage)
	DECLARE_OLECREATE_EX(CDXInfoEkeyActiveXPropPage)

// 构造函数
public:
	CDXInfoEkeyActiveXPropPage();

// 对话框数据
	enum { IDD = IDD_PROPPAGE_DXINFOEKEYACTIVEX };

// 实现
protected:
	virtual void DoDataExchange(CDataExchange* pDX);    // DDX/DDV 支持

// 消息映射
protected:
	DECLARE_MESSAGE_MAP()
};

