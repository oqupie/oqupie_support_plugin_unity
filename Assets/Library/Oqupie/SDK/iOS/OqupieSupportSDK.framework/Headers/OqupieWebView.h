#ifndef OqupieWebView_h
#define OqupieWebView_h

#import <Foundation/Foundation.h>
#import <UIKit/UIKit.h>
#import <WebKit/WebKit.h>
#import "OQAppInfo.h"

// 웹뷰
@interface OqupieWebView: NSObject
@property WKWebView* webView;
@property UIView* titleBar;
@property UILabel* labelTitle;
@property UIButton* buttonClose;
@property UIButton* buttonBack;
- (void)createWebView: (NSString*)url appInfo: (OQAppInfo*)appInfo showTitleBar: (BOOL)showTitleBar title: (NSString*)title color: (UIColor*)color;
+ (UIViewController*)getTopMostViewController;
+ (UIViewController*)getTopMostViewController: (UIViewController*) controller;
- (void)changeRotation: (BOOL)landscape;
- (UIImage*)loadImage: (NSString*)pathForResource ofType: (NSString*)ofType;
- (UIImage*)resize: (UIImage*)sourceImage size: (CGSize)size;
- (void)closeWebView;
- (void)goBack;
@end

#endif /* OqupieWebView_h */
