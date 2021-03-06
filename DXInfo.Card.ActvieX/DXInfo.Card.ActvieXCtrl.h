#pragma once

// DXInfo.Card.ActvieXCtrl.h : CDXInfoCardActvieXCtrl ActiveX 控件类的声明。


// CDXInfoCardActvieXCtrl : 有关实现的信息，请参阅 DXInfo.Card.ActvieXCtrl.cpp。

class CDXInfoCardActvieXCtrl : public COleControl
{
	DECLARE_DYNCREATE(CDXInfoCardActvieXCtrl)

// 构造函数
public:
	CDXInfoCardActvieXCtrl();

// 重写
public:
	virtual void OnDraw(CDC* pdc, const CRect& rcBounds, const CRect& rcInvalid);
	virtual void DoPropExchange(CPropExchange* pPX);
	virtual void OnResetState();

// 实现
protected:
	~CDXInfoCardActvieXCtrl();

	DECLARE_OLECREATE_EX(CDXInfoCardActvieXCtrl)    // 类工厂和 guid
	DECLARE_OLETYPELIB(CDXInfoCardActvieXCtrl)      // GetTypeInfo
	DECLARE_PROPPAGEIDS(CDXInfoCardActvieXCtrl)     // 属性页 ID
	DECLARE_OLECTLTYPE(CDXInfoCardActvieXCtrl)		// 类型名称和杂项状态

// 消息映射
	DECLARE_MESSAGE_MAP()

// 调度映射
	DECLARE_DISPATCH_MAP()

	afx_msg void AboutBox();

// 事件映射
	DECLARE_EVENT_MAP()

// 调度和事件 ID
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

