// ���� ifdef ���Ǵ���ʹ�� DLL �������򵥵�
// ��ı�׼�������� DLL �е������ļ��������������϶���� DXINFOCARD_EXPORTS
// ���ű���ġ���ʹ�ô� DLL ��
// �κ�������Ŀ�ϲ�Ӧ����˷��š�������Դ�ļ��а������ļ����κ�������Ŀ���Ὣ
// DXINFOCARD_API ������Ϊ�Ǵ� DLL ����ģ����� DLL ���ô˺궨���
// ������Ϊ�Ǳ������ġ�
#ifdef DXINFOCARD_EXPORTS
#define DXINFOCARD_API __declspec(dllexport)
#else
#define DXINFOCARD_API __declspec(dllimport)
#endif

// �����Ǵ� DXInfo.Card.dll ������
class DXINFOCARD_API CDXInfoCard {
public:
	CDXInfoCard(CString akey,CString bkey,CString akey_old,CString bkey_old,long baund=9600,int port=0,int sector=1);
	// TODO: �ڴ�������ķ�����
	bool ReadCard(unsigned char data[33]);
	bool PutCard(unsigned char data[33]);
	bool RecycleCard();
private:
	HANDLE icdev;
	long m_baund;
	int m_Port;
	int m_Sector;	
	CString m_akey;
	CString m_bkey;
	CString m_akey_old;
	CString m_bkey_old;
};
