

/* this ALWAYS GENERATED file contains the definitions for the interfaces */


 /* File created by MIDL compiler version 7.00.0555 */
/* at Sun Apr 17 10:39:38 2011
 */
/* Compiler settings for DXInfoEkeyActiveX.idl:
    Oicf, W1, Zp8, env=Win32 (32b run), target_arch=X86 7.00.0555 
    protocol : dce , ms_ext, c_ext, robust
    error checks: allocation ref bounds_check enum stub_data 
    VC __declspec() decoration level: 
         __declspec(uuid()), __declspec(selectany), __declspec(novtable)
         DECLSPEC_UUID(), MIDL_INTERFACE()
*/
/* @@MIDL_FILE_HEADING(  ) */

#pragma warning( disable: 4049 )  /* more than 64k source lines */


/* verify that the <rpcndr.h> version is high enough to compile this file*/
#ifndef __REQUIRED_RPCNDR_H_VERSION__
#define __REQUIRED_RPCNDR_H_VERSION__ 475
#endif

#include "rpc.h"
#include "rpcndr.h"

#ifndef __RPCNDR_H_VERSION__
#error this stub requires an updated version of <rpcndr.h>
#endif // __RPCNDR_H_VERSION__


#ifndef __DXInfo2EEkey2EActiveXidl_h__
#define __DXInfo2EEkey2EActiveXidl_h__

#if defined(_MSC_VER) && (_MSC_VER >= 1020)
#pragma once
#endif

/* Forward Declarations */ 

#ifndef ___DDXInfoEkeyActiveX_FWD_DEFINED__
#define ___DDXInfoEkeyActiveX_FWD_DEFINED__
typedef interface _DDXInfoEkeyActiveX _DDXInfoEkeyActiveX;
#endif 	/* ___DDXInfoEkeyActiveX_FWD_DEFINED__ */


#ifndef ___DDXInfoEkeyActiveXEvents_FWD_DEFINED__
#define ___DDXInfoEkeyActiveXEvents_FWD_DEFINED__
typedef interface _DDXInfoEkeyActiveXEvents _DDXInfoEkeyActiveXEvents;
#endif 	/* ___DDXInfoEkeyActiveXEvents_FWD_DEFINED__ */


#ifndef __DXInfoEkeyActiveX_FWD_DEFINED__
#define __DXInfoEkeyActiveX_FWD_DEFINED__

#ifdef __cplusplus
typedef class DXInfoEkeyActiveX DXInfoEkeyActiveX;
#else
typedef struct DXInfoEkeyActiveX DXInfoEkeyActiveX;
#endif /* __cplusplus */

#endif 	/* __DXInfoEkeyActiveX_FWD_DEFINED__ */


#ifdef __cplusplus
extern "C"{
#endif 



#ifndef __DXInfoEkeyActiveXLib_LIBRARY_DEFINED__
#define __DXInfoEkeyActiveXLib_LIBRARY_DEFINED__

/* library DXInfoEkeyActiveXLib */
/* [control][version][uuid] */ 


EXTERN_C const IID LIBID_DXInfoEkeyActiveXLib;

#ifndef ___DDXInfoEkeyActiveX_DISPINTERFACE_DEFINED__
#define ___DDXInfoEkeyActiveX_DISPINTERFACE_DEFINED__

/* dispinterface _DDXInfoEkeyActiveX */
/* [uuid] */ 


EXTERN_C const IID DIID__DDXInfoEkeyActiveX;

#if defined(__cplusplus) && !defined(CINTERFACE)

    MIDL_INTERFACE("42E5B082-0DE9-437B-BBF3-F779DEA99A33")
    _DDXInfoEkeyActiveX : public IDispatch
    {
    };
    
#else 	/* C style interface */

    typedef struct _DDXInfoEkeyActiveXVtbl
    {
        BEGIN_INTERFACE
        
        HRESULT ( STDMETHODCALLTYPE *QueryInterface )( 
            _DDXInfoEkeyActiveX * This,
            /* [in] */ REFIID riid,
            /* [annotation][iid_is][out] */ 
            __RPC__deref_out  void **ppvObject);
        
        ULONG ( STDMETHODCALLTYPE *AddRef )( 
            _DDXInfoEkeyActiveX * This);
        
        ULONG ( STDMETHODCALLTYPE *Release )( 
            _DDXInfoEkeyActiveX * This);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfoCount )( 
            _DDXInfoEkeyActiveX * This,
            /* [out] */ UINT *pctinfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfo )( 
            _DDXInfoEkeyActiveX * This,
            /* [in] */ UINT iTInfo,
            /* [in] */ LCID lcid,
            /* [out] */ ITypeInfo **ppTInfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetIDsOfNames )( 
            _DDXInfoEkeyActiveX * This,
            /* [in] */ REFIID riid,
            /* [size_is][in] */ LPOLESTR *rgszNames,
            /* [range][in] */ UINT cNames,
            /* [in] */ LCID lcid,
            /* [size_is][out] */ DISPID *rgDispId);
        
        /* [local] */ HRESULT ( STDMETHODCALLTYPE *Invoke )( 
            _DDXInfoEkeyActiveX * This,
            /* [in] */ DISPID dispIdMember,
            /* [in] */ REFIID riid,
            /* [in] */ LCID lcid,
            /* [in] */ WORD wFlags,
            /* [out][in] */ DISPPARAMS *pDispParams,
            /* [out] */ VARIANT *pVarResult,
            /* [out] */ EXCEPINFO *pExcepInfo,
            /* [out] */ UINT *puArgErr);
        
        END_INTERFACE
    } _DDXInfoEkeyActiveXVtbl;

    interface _DDXInfoEkeyActiveX
    {
        CONST_VTBL struct _DDXInfoEkeyActiveXVtbl *lpVtbl;
    };

    

#ifdef COBJMACROS


#define _DDXInfoEkeyActiveX_QueryInterface(This,riid,ppvObject)	\
    ( (This)->lpVtbl -> QueryInterface(This,riid,ppvObject) ) 

#define _DDXInfoEkeyActiveX_AddRef(This)	\
    ( (This)->lpVtbl -> AddRef(This) ) 

#define _DDXInfoEkeyActiveX_Release(This)	\
    ( (This)->lpVtbl -> Release(This) ) 


#define _DDXInfoEkeyActiveX_GetTypeInfoCount(This,pctinfo)	\
    ( (This)->lpVtbl -> GetTypeInfoCount(This,pctinfo) ) 

#define _DDXInfoEkeyActiveX_GetTypeInfo(This,iTInfo,lcid,ppTInfo)	\
    ( (This)->lpVtbl -> GetTypeInfo(This,iTInfo,lcid,ppTInfo) ) 

#define _DDXInfoEkeyActiveX_GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)	\
    ( (This)->lpVtbl -> GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId) ) 

#define _DDXInfoEkeyActiveX_Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)	\
    ( (This)->lpVtbl -> Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr) ) 

#endif /* COBJMACROS */


#endif 	/* C style interface */


#endif 	/* ___DDXInfoEkeyActiveX_DISPINTERFACE_DEFINED__ */


#ifndef ___DDXInfoEkeyActiveXEvents_DISPINTERFACE_DEFINED__
#define ___DDXInfoEkeyActiveXEvents_DISPINTERFACE_DEFINED__

/* dispinterface _DDXInfoEkeyActiveXEvents */
/* [uuid] */ 


EXTERN_C const IID DIID__DDXInfoEkeyActiveXEvents;

#if defined(__cplusplus) && !defined(CINTERFACE)

    MIDL_INTERFACE("C719E07A-1214-4536-B717-25E3C2ECBF91")
    _DDXInfoEkeyActiveXEvents : public IDispatch
    {
    };
    
#else 	/* C style interface */

    typedef struct _DDXInfoEkeyActiveXEventsVtbl
    {
        BEGIN_INTERFACE
        
        HRESULT ( STDMETHODCALLTYPE *QueryInterface )( 
            _DDXInfoEkeyActiveXEvents * This,
            /* [in] */ REFIID riid,
            /* [annotation][iid_is][out] */ 
            __RPC__deref_out  void **ppvObject);
        
        ULONG ( STDMETHODCALLTYPE *AddRef )( 
            _DDXInfoEkeyActiveXEvents * This);
        
        ULONG ( STDMETHODCALLTYPE *Release )( 
            _DDXInfoEkeyActiveXEvents * This);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfoCount )( 
            _DDXInfoEkeyActiveXEvents * This,
            /* [out] */ UINT *pctinfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfo )( 
            _DDXInfoEkeyActiveXEvents * This,
            /* [in] */ UINT iTInfo,
            /* [in] */ LCID lcid,
            /* [out] */ ITypeInfo **ppTInfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetIDsOfNames )( 
            _DDXInfoEkeyActiveXEvents * This,
            /* [in] */ REFIID riid,
            /* [size_is][in] */ LPOLESTR *rgszNames,
            /* [range][in] */ UINT cNames,
            /* [in] */ LCID lcid,
            /* [size_is][out] */ DISPID *rgDispId);
        
        /* [local] */ HRESULT ( STDMETHODCALLTYPE *Invoke )( 
            _DDXInfoEkeyActiveXEvents * This,
            /* [in] */ DISPID dispIdMember,
            /* [in] */ REFIID riid,
            /* [in] */ LCID lcid,
            /* [in] */ WORD wFlags,
            /* [out][in] */ DISPPARAMS *pDispParams,
            /* [out] */ VARIANT *pVarResult,
            /* [out] */ EXCEPINFO *pExcepInfo,
            /* [out] */ UINT *puArgErr);
        
        END_INTERFACE
    } _DDXInfoEkeyActiveXEventsVtbl;

    interface _DDXInfoEkeyActiveXEvents
    {
        CONST_VTBL struct _DDXInfoEkeyActiveXEventsVtbl *lpVtbl;
    };

    

#ifdef COBJMACROS


#define _DDXInfoEkeyActiveXEvents_QueryInterface(This,riid,ppvObject)	\
    ( (This)->lpVtbl -> QueryInterface(This,riid,ppvObject) ) 

#define _DDXInfoEkeyActiveXEvents_AddRef(This)	\
    ( (This)->lpVtbl -> AddRef(This) ) 

#define _DDXInfoEkeyActiveXEvents_Release(This)	\
    ( (This)->lpVtbl -> Release(This) ) 


#define _DDXInfoEkeyActiveXEvents_GetTypeInfoCount(This,pctinfo)	\
    ( (This)->lpVtbl -> GetTypeInfoCount(This,pctinfo) ) 

#define _DDXInfoEkeyActiveXEvents_GetTypeInfo(This,iTInfo,lcid,ppTInfo)	\
    ( (This)->lpVtbl -> GetTypeInfo(This,iTInfo,lcid,ppTInfo) ) 

#define _DDXInfoEkeyActiveXEvents_GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)	\
    ( (This)->lpVtbl -> GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId) ) 

#define _DDXInfoEkeyActiveXEvents_Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)	\
    ( (This)->lpVtbl -> Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr) ) 

#endif /* COBJMACROS */


#endif 	/* C style interface */


#endif 	/* ___DDXInfoEkeyActiveXEvents_DISPINTERFACE_DEFINED__ */


EXTERN_C const CLSID CLSID_DXInfoEkeyActiveX;

#ifdef __cplusplus

class DECLSPEC_UUID("5790C5F1-AAF8-4E72-BDE7-8605A5000AD4")
DXInfoEkeyActiveX;
#endif
#endif /* __DXInfoEkeyActiveXLib_LIBRARY_DEFINED__ */

/* Additional Prototypes for ALL interfaces */

/* end of Additional Prototypes */

#ifdef __cplusplus
}
#endif

#endif


