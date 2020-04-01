#import <Foundation/Foundation.h>

@interface OQLogger : NSObject
{
    int logLevel;
}

+ (void)trace:(NSString *)message;

@end
