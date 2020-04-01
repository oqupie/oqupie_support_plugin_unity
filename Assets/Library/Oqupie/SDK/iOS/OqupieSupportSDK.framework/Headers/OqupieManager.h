#ifndef OqupieManager_h
#define OqupieManager_h

#import <Foundation/Foundation.h>
#import "OqupieWebView.h"
#import "OQAppInfo.h"

@interface OqupieManager : NSObject

@property OqupieWebView* oqupieWebView;
+ (id)sharedInstance;
- (OQAppInfo*)getAppInfo;
- (void)openWebView: (NSString*)url appInfo: (OQAppInfo*)appInfo showTitleBar: (BOOL)showTitleBar title: (NSString*)title color: (UIColor*)color;
- (void)preOpenWebView: (NSString*)url appInfo: (OQAppInfo*)appInfo showTitleBar: (BOOL)showTitleBar title: (NSString*)title color: (UIColor*)color;
- (void)closeWebView;

@end

#endif /* OqupieManager_h */


