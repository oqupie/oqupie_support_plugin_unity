#ifndef OqupieBridge_h
#define OqupieBridge_h


#if __cplusplus
extern "C"
{
#endif

    void oqupieOpenWebView(const char* url, const char* appInfoQueryString, bool showTitleBar, const char* title, int red, int green, int blue);
    
#if __cplusplus
}
#endif

#endif /* OqupieBridge_h */
