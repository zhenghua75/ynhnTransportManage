#pragma once

// DXInfo.Card.ActvieXPropPage.h : CDXInfoCardActvieXPropPage 属性页类的声明。


// CDXInfoCardActvieXPropPage : 有关实现的信息，请参阅 DXInfo.Card.ActvieXPropPage.cpp。

class CDXInfoCardActvieXPropPage : public COlePropertyPage
{
	DECLARE_DYNCREATE(CDXInfoCardActvieXPropPage)
	DECLARE_OLECREATE_EX(CDXInfoCardActvieXPropPage)

// 构造函数
public:
	CDXInfoCardActvieXPropPage();

// 对话框数据
	enum { IDD = IDD_PROPPAGE_DXINFOCARDACTVIEX };

// 实现
protected:
	virtual void DoDataExchange(CDataExchange* pDX);    // DDX/DDV 支持

// 消息映射
protected:
	DECLARE_MESSAGE_MAP()
};

