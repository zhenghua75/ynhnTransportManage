// dllmain.h : 模块类的声明。

class CDXInfoCardActiveXModule : public ATL::CAtlDllModuleT< CDXInfoCardActiveXModule >
{
public :
	DECLARE_LIBID(LIBID_DXInfoCardActiveXLib)
	DECLARE_REGISTRY_APPID_RESOURCEID(IDR_DXINFOCARDACTIVEX, "{51FED5FC-5283-4CBD-B801-046D337A458C}")
};

extern class CDXInfoCardActiveXModule _AtlModule;
