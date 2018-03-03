// Card.cpp : CCard ��ʵ��
#include "stdafx.h"
#include "Card.h"
#include "atlstr.h"
#include "DXInfoCard.h"
// CCard


STDMETHODIMP CCard::ReadCard(BSTR* data)
{
	// TODO: �ڴ����ʵ�ִ���
	CString strResult;
	
	// TODO: �ڴ���ӵ��ȴ���������
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
	// TODO: �ڴ����ʵ�ִ���
	CString akey("123456789012");
	CString bkey("123456789012");
	CString akey_old("123456789012");
	CString bkey_old("123456789012");
	CDXInfoCard card(akey,bkey,akey_old,bkey_old);

	//-----------------
	int length = SysStringLen(data);  //ȡBSTR����
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
	// TODO: �ڴ����ʵ�ִ���
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
