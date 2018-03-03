// Card.cpp : CCard 的实现
#include "stdafx.h"
#include "Card.h"
#include "atlstr.h"
#include "DXInfoCard.h"
// CCard


STDMETHODIMP CCard::ReadCard(BSTR* data)
{
	// TODO: 在此添加实现代码
	CString strResult;
	
	// TODO: 在此添加调度处理程序代码
	unsigned char reddata[33];
	CString akey("123456789012");
	CString bkey("123456789012");
	CString akey_old("123456789012");
	CString bkey_old("123456789012");
	CDXInfoCard card(akey,bkey,akey_old,bkey_old);
	if(card.ReadCard(reddata))
		strResult.Format("%s",reddata);
	else
		strResult="";
	*data = strResult.AllocSysString();
	return S_OK;
}


STDMETHODIMP CCard::PutCard(BSTR data, VARIANT_BOOL* issuc)
{
	// TODO: 在此添加实现代码
	CString akey("123456789012");
	CString bkey("123456789012");
	CString akey_old("123456789012");
	CString bkey_old("123456789012");
	CDXInfoCard card(akey,bkey,akey_old,bkey_old);

	//-----------------
	int length = SysStringLen(data);  //取BSTR长度
	unsigned char b[33]; 
	memset(b,0,33);
	for(int i=0; i <length; i++)b[i]=(unsigned char)data[i]; 
	if(card.PutCard(b))
		*issuc=true;
	else
		*issuc=false;
	return S_OK;
}


STDMETHODIMP CCard::RecycleCard(VARIANT_BOOL* issuc)
{
	// TODO: 在此添加实现代码
	CString akey("123456789012");
	CString bkey("123456789012");
	CString akey_old("123456789012");
	CString bkey_old("123456789012");
	CDXInfoCard card(akey,bkey,akey_old,bkey_old);
	if(card.RecycleCard())
		*issuc=true;
	else
		*issuc=false;
	return S_OK;
}
