#ifndef AppInfo_h
#define AppInfo_h
#import <Foundation/Foundation.h>

@interface OQAppInfo : NSObject

@property NSString* endPoint;
@property NSMutableDictionary* additionalInfo;

- (id)init;
- (NSURLComponents*)toQueryString;
- (void)addInfo: (NSString*)key forKey: (NSString*)value;
+ (OQAppInfo*)fromQueryString: (NSString*)queryString;

@end

#endif /* AppInfo_h */
