

/* this ALWAYS GENERATED file contains the definitions for the interfaces */


 /* File created by MIDL compiler version 7.00.0555 */
/* at Sun Apr 17 10:39:39 2011
 */
/* Compiler settings for DXInfoCardActvieX.idl:
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


#ifndef __DXInfo2ECard2EActvieXidl_h__
#define __DXInfo2ECard2EActvieXidl_h__

#if defined(_MSC_VER) && (_MSC_VER >= 1020)
#pragma once
#endif

/* Forward Declarations */ 

#ifndef ___DDXInfoCardActvieX_FWD_DEFINED__
#define ___DDXInfoCardActvieX_FWD_DEFINED__
typedef interface _DDXInfoCardActvieX _DDXInfoCardActvieX;
#endif 	/* ___DDXInfoCardActvieX_FWD_DEFINED__ */


#ifndef ___DDXInfoCardActvieXEvents_FWD_DEFINED__
#define ___DDXInfoCardActvieXEvents_FWD_DEFINED__
typedef interface _DDXInfoCardActvieXEvents _DDXInfoCardActvieXEvents;
#endif 	/* ___DDXInfoCardActvieXEvents_FWD_DEFINED__ */


#ifndef __DXInfoCardActvieX_FWD_DEFINED__
#define __DXInfoCardActvieX_FWD_DEFINED__

#ifdef __cplusplus
typedef class DXInfoCardActvieX DXInfoCardActvieX;
#else
typedef struct DXInfoCardActvieX DXInfoCardActvieX;
#endif /* __cplusplus */

#endif 	/* __DXInfoCardActvieX_FWD_DEFINED__ */


#ifdef __cplusplus
extern "C"{
#endif 



#ifndef __DXInfoCardActvieXLib_LIBRARY_DEFINED__
#define __DXInfoCardActvieXLib_LIBRARY_DEFINED__

/* library DXInfoCardActvieXLib */
/* [control][version][uuid] */ 


EXTERN_C const IID LIBID_DXInfoCardActvieXLib;

#ifndef ___DDXInfoCardActvieX_DISPINTERFACE_DEFINED__
#define ___DDXInfoCardActvieX_DISPINTERFACE_DEFINED__

/* dispinterface _DDXInfoCardActvieX */
/* [uuid] */ 


EXTERN_C const IID DIID__DDXInfoCardActvieX;

#if defined(__cplusplus) && !defined(CINTERFACE)

    MIDL_INTERFACE("4E12BC45-D49E-400D-86FA-DE5D29132BF1")
    _DDXInfoCardActvieX : public IDispatch
    {
    };
    
#else 	/* C style interface */

    typedef struct _DDXInfoCardActvieXVtbl
    {
        BEGIN_INTERFACE
        
        HRESULT ( STDMETHODCALLTYPE *QueryInterface )( 
            _DDXInfoCardActvieX * This,
            /* [in] */ REFIID riid,
            /* [annotation][iid_is][out] */ 
            __RPC__deref_out  void **ppvObject);
        
        ULONG ( STDMETHODCALLTYPE *AddRef )( 
            _DDXInfoCardActvieX * This);
        
        ULONG ( STDMETHODCALLTYPE *Release )( 
            _DDXInfoCardActvieX * This);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfoCount )( 
            _DDXInfoCardActvieX * This,
            /* [out] */ UINT *pctinfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfo )( 
            _DDXInfoCardActvieX * This,
            /* [in] */ UINT iTInfo,
            /* [in] */ LCID lcid,
            /* [out] */ ITypeInfo **ppTInfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetIDsOfNames )( 
            _DDXInfoCardActvieX * This,
            /* [in] */ REFIID riid,
            /* [size_is][in] */ LPOLESTR *rgszNames,
            /* [range][in] */ UINT cNames,
            /* [in] */ LCID lcid,
            /* [size_is][out] */ DISPID *rgDispId);
        
        /* [local] */ HRESULT ( STDMETHODCALLTYPE *Invoke )( 
            _DDXInfoCardActvieX * This,
            /* [in] */ DISPID dispIdMember,
            /* [in] */ REFIID riid,
            /* [in] */ LCID lcid,
            /* [in] */ WORD wFlags,
            /* [out][in] */ DISPPARAMS *pDispParams,
            /* [out] */ VARIANT *pVarResult,
            /* [out] */ EXCEPINFO *pExcepInfo,
            /* [out] */ UINT *puArgErr);
        
        END_INTERFACE
    } _DDXInfoCardActvieXVtbl;

    interface _DDXInfoCardActvieX
    {
        CONST_VTBL struct _DDXInfoCardActvieXVtbl *lpVtbl;
    };

    

#ifdef COBJMACROS


#define _DDXInfoCardActvieX_QueryInterface(This,riid,ppvObject)	\
    ( (This)->lpVtbl -> QueryInterface(This,riid,ppvObject) ) 

#define _DDXInfoCardActvieX_AddRef(This)	\
    ( (This)->lpVtbl -> AddRef(This) ) 

#define _DDXInfoCardActvieX_Release(This)	\
    ( (This)->lpVtbl -> Release(This) ) 


#define _DDXInfoCardActvieX_GetTypeInfoCount(This,pctinfo)	\
    ( (This)->lpVtbl -> GetTypeInfoCount(This,pctinfo) ) 

#define _DDXInfoCardActvieX_GetTypeInfo(This,iTInfo,lcid,ppTInfo)	\
    ( (This)->lpVtbl -> GetTypeInfo(This,iTInfo,lcid,ppTInfo) ) 

#define _DDXInfoCardActvieX_GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)	\
    ( (This)->lpVtbl -> GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId) ) 

#define _DDXInfoCardActvieX_Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)	\
    ( (This)->lpVtbl -> Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr) ) 

#endif /* COBJMACROS */


#endif 	/* C style interface */


#endif 	/* ___DDXInfoCardActvieX_DISPINTERFACE_DEFINED__ */


#ifndef ___DDXInfoCardActvieXEvents_DISPINTERFACE_DEFINED__
#define ___DDXInfoCardActvieXEvents_DISPINTERFACE_DEFINED__

/* dispinterface _DDXInfoCardActvieXEvents */
/* [uuid] */ 


EXTERN_C const IID DIID__DDXInfoCardActvieXEvents;

#if defined(__cplusplus) && !defined(CINTERFACE)

    MIDL_INTERFACE("BAB78D8C-29BA-4661-B1A4-91517276417D")
    _DDXInfoCardActvieXEvents : public IDispatch
    {
    };
    
#else 	/* C style interface */

    typedef struct _DDXInfoCardActvieXEventsVtbl
    {
        BEGIN_INTERFACE
        
        HRESULT ( STDMETHODCALLTYPE *QueryInterface )( 
            _DDXInfoCardActvieXEvents * This,
            /* [in] */ REFIID riid,
            /* [annotation][iid_is][out] */ 
            __RPC__deref_out  void **ppvObject);
        
        ULONG ( STDMETHODCALLTYPE *AddRef )( 
            _DDXInfoCardActvieXEvents * This);
        
        ULONG ( STDMETHODCALLTYPE *Release )( 
            _DDXInfoCardActvieXEvents * This);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfoCount )( 
            _DDXInfoCardActvieXEvents * This,
            /* [out] */ UINT *pctinfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfo )( 
            _DDXInfoCardActvieXEvents * This,
            /* [in] */ UINT iTInfo,
            /* [in] */ LCID lcid,
            /* [out] */ ITypeInfo **ppTInfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetIDsOfNames )( 
            _DDXInfoCardActvieXEvents * This,
            /* [in] */ REFIID riid,
            /* [size_is][in] */ LPOLESTR *rgszNames,
            /* [range][in] */ UINT cNames,
            /* [in] */ LCID lcid,
            /* [size_is][out] */ DISPID *rgDispId);
        
        /* [local] */ HRESULT ( STDMETHODCALLTYPE *Invoke )( 
            _DDXInfoCardActvieXEvents * This,
            /* [in] */ DISPID dispIdMember,
            /* [in] */ REFIID riid,
            /* [in] */ LCID lcid,
            /* [in] */ WORD wFlags,
            /* [out][in] */ DISPPARAMS *pDispParams,
            /* [out] */ VARIANT *pVarResult,
            /* [out] */ EXCEPINFO *pExcepInfo,
            /* [out] */ UINT *puArgErr);
        
        END_INTERFACE
    } _DDXInfoCardActvieXEventsVtbl;

    interface _DDXInfoCardActvieXEvents
    {
        CONST_VTBL struct _DDXInfoCardActvieXEventsVtbl *lpVtbl;
    };

    

#ifdef COBJMACROS


#define _DDXInfoCardActvieXEvents_QueryInterface(This,riid,ppvObject)	\
    ( (This)->lpVtbl -> QueryInterface(This,riid,ppvObject) ) 

#define _DDXInfoCardActvieXEvents_AddRef(This)	\
    ( (This)->lpVtbl -> AddRef(This) ) 

#define _DDXInfoCardActvieXEvents_Release(This)	\
    ( (This)->lpVtbl -> Release(This) ) 


#define _DDXInfoCardActvieXEvents_GetTypeInfoCount(This,pctinfo)	\
    ( (This)->lpVtbl -> GetTypeInfoCount(This,pctinfo) ) 

#define _DDXInfoCardActvieXEvents_GetTypeInfo(This,iTInfo,lcid,ppTInfo)	\
    ( (This)->lpVtbl -> GetTypeInfo(This,iTInfo,lcid,ppTInfo) ) 

#define _DDXInfoCardActvieXEvents_GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)	\
    ( (This)->lpVtbl -> GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId) ) 

#define _DDXInfoCardActvieXEvents_Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)	\
    ( (This)->lpVtbl -> Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr) ) 

#endif /* COBJMACROS */


#endif 	/* C style interface */


#endif 	/* ___DDXInfoCardActvieXEvents_DISPINTERFACE_DEFINED__ */


EXTERN_C const CLSID CLSID_DXInfoCardActvieX;

#ifdef __cplusplus

class DECLSPEC_UUID("43246D5D-8E72-43C9-BAB1-EE733C3DDCA4")
DXInfoCardActvieX;
#endif
#endif /* __DXInfoCardActvieXLib_LIBRARY_DEFINED__ */

/* Additional Prototypes for ALL interfaces */

/* end of Additional Prototypes */

#ifdef __cplusplus
}
#endif

#endif


