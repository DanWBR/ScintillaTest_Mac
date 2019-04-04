using System;
using AppKit;
using CoreGraphics;
using Foundation;
using ObjCRuntime;

namespace ScintillaBinder
{
    // @protocol InfoBarCommunicator
    [BaseType(typeof(NSObject))]
    [Model]
    interface InfoBarCommunicator
    {
        // @required -(void)notify:(NotificationType)type message:(NSString *)message location:(NSPoint)location value:(float)value;
        [Abstract]
        [Export("notify:message:location:value:")]
        void Notify(NotificationType type, string message, CGPoint location, float value);

        // @required -(void)setCallback:(id<InfoBarCommunicator>)callback;
        [Abstract]
        [Export("setCallback:")]
        void SetCallback(InfoBarCommunicator callback);
    }

    // @interface VerticallyCenteredTextFieldCell : NSTextFieldCell
    [BaseType(typeof(NSTextFieldCell))]
    interface VerticallyCenteredTextFieldCell
    {
    }

    // @interface InfoBar : NSView <InfoBarCommunicator>
    [BaseType(typeof(NSView))]
    interface InfoBar : InfoBarCommunicator
    {
        //// -(void)notify:(NotificationType)type message:(NSString *)message location:(NSPoint)location value:(float)value;
        //[Export("notify:message:location:value:")]
        //void Notify(NotificationType type, string message, CGPoint location, float value);

        //// -(void)setCallback:(id<InfoBarCommunicator>)callback;
        //[Export("setCallback:")]
        //void SetCallback(InfoBarCommunicator callback);

        // -(void)createItems;
        [Export("createItems")]
        void CreateItems();

        // -(void)positionSubViews;
        [Export("positionSubViews")]
        void PositionSubViews();

        // -(void)setDisplay:(IBDisplay)display;
        [Export("setDisplay:")]
        void SetDisplay(IBDisplay display);

        // -(void)zoomItemAction:(id)sender;
        [Export("zoomItemAction:")]
        void ZoomItemAction(NSObject sender);

        // -(void)setScaleFactor:(float)newScaleFactor adjustPopup:(BOOL)flag;
        [Export("setScaleFactor:adjustPopup:")]
        void SetScaleFactor(float newScaleFactor, bool flag);

        // -(void)setCaretPosition:(NSPoint)position;
        [Export("setCaretPosition:")]
        void SetCaretPosition(CGPoint position);

        // -(void)sizeToFit;
        [Export("sizeToFit")]
        void SizeToFit();
    }

    //[Static]
    //partial interface Constants
    //{
    //    // extern int QuartzFont;
    //    [Field("QuartzFont")]
    //    int QuartzFont { get; }

    //    // extern int QuartzTextStyle;
    //    [Field("QuartzTextStyle")]
    //    int QuartzTextStyle { get; }

    //    // extern int QuartzTextLayout;
    //    [Field("QuartzTextLayout")]
    //    int QuartzTextLayout { get; }
    //}

    // @interface ScintillaContextMenu : NSMenu
    [BaseType(typeof(NSMenu))]
    interface ScintillaContextMenu
    {
        // -(void)handleCommand:(NSMenuItem *)sender;
        [Export("handleCommand:")]
        void HandleCommand(NSMenuItem sender);

        // -(void)setOwner:(id)newOwner;
        [Export("setOwner:")]
        void SetOwner(NSObject newOwner);
    }

    //// @interface TimerTarget : NSObject
    //[BaseType(typeof(NSObject))]
    //interface TimerTarget
    //{
    //    // -(id)init:(void *)target;
    //    [Export("init:")]
    //    unsafe IntPtr Constructor(void* target);

    //    // -(void)timerFired:(NSTimer *)timer;
    //    [Export("timerFired:")]
    //    void TimerFired(NSTimer timer);

    //    // -(void)idleTimerFired:(NSTimer *)timer;
    //    [Export("idleTimerFired:")]
    //    void IdleTimerFired(NSTimer timer);

    //    // -(void)idleTriggered:(NSNotification *)notification;
    //    [Export("idleTriggered:")]
    //    void IdleTriggered(NSNotification notification);
    //}

    partial interface Constants
    {
        // extern int Scintilla;
        [Field("Scintilla")]
        int Scintilla { get; }

        // extern NSString *const SCIUpdateUINotification;
        [Field("SCIUpdateUINotification")]
        NSString SCIUpdateUINotification { get; }
    }

    // @protocol ScintillaNotificationProtocol
    [BaseType(typeof(NSObject))]
    [Model]
    interface IScintillaNotificationProtocol
    {
        // @required -(void)notification:(id)notification;
        [Abstract]
        [Export("notification:")]
        void Notification(NSObject notification);
    }

    // @interface SCIScrollView : NSScrollView
    [BaseType(typeof(NSScrollView))]
    interface SCIScrollView
    {
    }

    // @interface SCIMarginView : NSRulerView
    [BaseType(typeof(NSRulerView))]
    interface SCIMarginView
    {
    }

    // @interface SCIContentView : NSView <NSTextInputClient, NSUserInterfaceValidations, NSDraggingSource, NSDraggingDestination, NSAccessibilityStaticText>
    [BaseType(typeof(NSView))]
    interface SCIContentView : INSTextInputClient, INSUserInterfaceValidations, INSDraggingSource, INSDraggingDestination
    {
        // -(void)setCursor:(int)cursor;
        [Export("setCursor:")]
        void SetCursor(int cursor);
    }

    // @interface ScintillaView : NSView <InfoBarCommunicator, ScintillaNotificationProtocol>
    [BaseType(typeof(NSView))]
    interface ScintillaView : InfoBarCommunicator, IScintillaNotificationProtocol
    {
        [Wrap("WeakDelegate")]
        IScintillaNotificationProtocol Delegate { get; set; }

        // @property (nonatomic, unsafe_unretained) id<ScintillaNotificationProtocol> delegate;
        [NullAllowed, Export("delegate", ArgumentSemantic.Assign)]
        NSObject WeakDelegate { get; set; }

        // @property (readonly, nonatomic) NSScrollView * scrollView;
        [Export("scrollView")]
        NSScrollView ScrollView { get; }

        // +(Class)contentViewClass;
        [Static]
        [Export("contentViewClass")]
        Class ContentViewClass { get; }

        //// -(void)notify:(NotificationType)type message:(NSString *)message location:(NSPoint)location value:(float)value;
        //[Export("notify:message:location:value:")]
        //void Notify(NotificationType type, string message, CGPoint location, float value);

        //// -(void)setCallback:(id<InfoBarCommunicator>)callback;
        //[Export("setCallback:")]
        //void SetCallback(InfoBarCommunicator callback);

        // -(void)suspendDrawing:(BOOL)suspend;
        [Export("suspendDrawing:")]
        void SuspendDrawing(bool suspend);

        //// -(void)notification:(id)notification;
        //[Export("notification:")]
        //void Notification(NSObject notification);

        // -(void)updateIndicatorIME;
        [Export("updateIndicatorIME")]
        void UpdateIndicatorIME();

        // -(void)setMarginWidth:(int)width;
        [Export("setMarginWidth:")]
        void SetMarginWidth(int width);

        // -(SCIContentView *)content;
        [Export("content")]
        SCIContentView Content { get; }

        // -(void)updateMarginCursors;
        [Export("updateMarginCursors")]
        void UpdateMarginCursors();

        // -(NSString *)string;
        // -(void)setString:(NSString *)aString;
        [Export("string")]
        string String { get; set; }

        // -(void)insertText:(id)aString;
        [Export("insertText:")]
        void InsertText(NSObject aString);

        // -(void)setEditable:(BOOL)editable;
        [Export("setEditable:")]
        void SetEditable(bool editable);

        // -(BOOL)isEditable;
        [Export("isEditable")]
        bool IsEditable();

        // -(NSRange)selectedRange;
        [Export("selectedRange")]
        NSRange SelectedRange();

        // -(NSRange)selectedRangePositions;
        [Export("selectedRangePositions")]
        NSRange SelectedRangePositions();

        // -(NSString *)selectedString;
        [Export("selectedString")]
        string SelectedString();

        // -(void)deleteRange:(NSRange)range;
        [Export("deleteRange:")]
        void DeleteRange(NSRange range);

        // -(void)setFontName:(NSString *)font size:(int)size bold:(BOOL)bold italic:(BOOL)italic;
        [Export("setFontName:size:bold:italic:")]
        void SetFontName(string font, int size, bool bold, bool italic);

        // +(id)directCall:(ScintillaView *)sender message:(unsigned int)message wParam:(id)wParam lParam:(id)lParam;
        [Static]
        [Export("directCall:message:wParam:lParam:")]
        NSObject DirectCall(ScintillaView sender, uint message, NSObject wParam, NSObject lParam);

        // -(id)message:(unsigned int)message wParam:(id)wParam lParam:(id)lParam;
        [Export("message:wParam:lParam:")]
        NSObject Message(uint message, NSObject wParam, NSObject lParam);

        // -(id)message:(unsigned int)message wParam:(id)wParam;
        [Export("message:wParam:")]
        NSObject Message(uint message, NSObject wParam);

        // -(id)message:(unsigned int)message;
        [Export("message:")]
        NSObject Message(uint message);

        // -(void)setGeneralProperty:(int)property parameter:(long)parameter value:(long)value;
        [Export("setGeneralProperty:parameter:value:")]
        void SetGeneralProperty(int property, nint parameter, nint value);

        // -(void)setGeneralProperty:(int)property value:(long)value;
        [Export("setGeneralProperty:value:")]
        void SetGeneralProperty(int property, nint value);

        // -(long)getGeneralProperty:(int)property;
        [Export("getGeneralProperty:")]
        nint GetGeneralProperty(int property);

        // -(long)getGeneralProperty:(int)property parameter:(long)parameter;
        [Export("getGeneralProperty:parameter:")]
        nint GetGeneralProperty(int property, nint parameter);

        // -(long)getGeneralProperty:(int)property parameter:(long)parameter extra:(long)extra;
        [Export("getGeneralProperty:parameter:extra:")]
        nint GetGeneralProperty(int property, nint parameter, nint extra);

        //// -(long)getGeneralProperty:(int)property ref:(const void *)ref;
        //[Export("getGeneralProperty:ref:")]
        //unsafe nint GetGeneralProperty(int property, void* @ref);

        // -(void)setColorProperty:(int)property parameter:(long)parameter value:(NSColor *)value;
        [Export("setColorProperty:parameter:value:")]
        void SetColorProperty(int property, nint parameter, NSColor value);

        // -(void)setColorProperty:(int)property parameter:(long)parameter fromHTML:(NSString *)fromHTML;
        [Export("setColorProperty:parameter:fromHTML:")]
        void SetColorProperty(int property, nint parameter, string fromHTML);

        // -(NSColor *)getColorProperty:(int)property parameter:(long)parameter;
        [Export("getColorProperty:parameter:")]
        NSColor GetColorProperty(int property, nint parameter);

        // -(void)setReferenceProperty:(int)property parameter:(long)parameter value:(const void *)value;
        [Export("setReferenceProperty:parameter:value:")]
        unsafe void SetReferenceProperty(int property, nint parameter, IntPtr value);

        // -(const void *)getReferenceProperty:(int)property parameter:(long)parameter;
        [Export("getReferenceProperty:parameter:")]
        unsafe IntPtr GetReferenceProperty(int property, nint parameter);

        // -(void)setStringProperty:(int)property parameter:(long)parameter value:(NSString *)value;
        [Export("setStringProperty:parameter:value:")]
        void SetStringProperty(int property, nint parameter, string value);

        // -(NSString *)getStringProperty:(int)property parameter:(long)parameter;
        [Export("getStringProperty:parameter:")]
        string GetStringProperty(int property, nint parameter);

        // -(void)setLexerProperty:(NSString *)name value:(NSString *)value;
        [Export("setLexerProperty:value:")]
        void SetLexerProperty(string name, string value);

        // -(NSString *)getLexerProperty:(NSString *)name;
        [Export("getLexerProperty:")]
        string GetLexerProperty(string name);

        // -(void)registerNotifyCallback:(intptr_t)windowid value:(id)callback __attribute__((deprecated("")));
        [Export("registerNotifyCallback:value:")]
        void RegisterNotifyCallback(IntPtr windowid, NSObject callback);

        // -(void)setInfoBar:(NSView<InfoBarCommunicator> *)aView top:(BOOL)top;
        [Export("setInfoBar:top:")]
        void SetInfoBar(InfoBar aView, bool top);

        // -(void)setStatusText:(NSString *)text;
        [Export("setStatusText:")]
        void SetStatusText(string text);

        // -(BOOL)findAndHighlightText:(NSString *)searchText matchCase:(BOOL)matchCase wholeWord:(BOOL)wholeWord scrollTo:(BOOL)scrollTo wrap:(BOOL)wrap;
        [Export("findAndHighlightText:matchCase:wholeWord:scrollTo:wrap:")]
        bool FindAndHighlightText(string searchText, bool matchCase, bool wholeWord, bool scrollTo, bool wrap);

        // -(BOOL)findAndHighlightText:(NSString *)searchText matchCase:(BOOL)matchCase wholeWord:(BOOL)wholeWord scrollTo:(BOOL)scrollTo wrap:(BOOL)wrap backwards:(BOOL)backwards;
        [Export("findAndHighlightText:matchCase:wholeWord:scrollTo:wrap:backwards:")]
        bool FindAndHighlightText(string searchText, bool matchCase, bool wholeWord, bool scrollTo, bool wrap, bool backwards);

        // -(int)findAndReplaceText:(NSString *)searchText byText:(NSString *)newText matchCase:(BOOL)matchCase wholeWord:(BOOL)wholeWord doAll:(BOOL)doAll;
        [Export("findAndReplaceText:byText:matchCase:wholeWord:doAll:")]
        int FindAndReplaceText(string searchText, string newText, bool matchCase, bool wholeWord, bool doAll);
    }
}
