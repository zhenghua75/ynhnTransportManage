// ���� ifdef ���Ǵ���ʹ�� DLL �������򵥵�
// ��ı�׼�������� DLL �е������ļ��������������϶���� DXINFOEKEY_EXPORTS
// ���ű���ġ���ʹ�ô� DLL ��
// �κ�������Ŀ�ϲ�Ӧ����˷��š�������Դ�ļ��а������ļ����κ�������Ŀ���Ὣ
// DXINFOEKEY_API ������Ϊ�Ǵ� DLL ����ģ����� DLL ���ô˺궨���
// ������Ϊ�Ǳ������ġ�
#ifdef DXINFOEKEY_EXPORTS
#define DXINFOEKEY_API __declspec(dllexport)
#else
#define DXINFOEKEY_API __declspec(dllimport)
#endif
// �����Ǵ� DXInfo.Ekey.dll ������
class DXINFOEKEY_API CDXInfoEkey {
public:
	CDXInfoEkey(CString projName,CString pwd);
	//��ȡӲ��ID
	bool GetHardwareID(char hdID[64]);
	// �Ƿ�ͨ����֤
	bool Verify(void);
private:
	CString m_projName;
	CString m_pwd;
};
