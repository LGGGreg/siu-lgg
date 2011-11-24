//********************************************************************************************
//Author: Sergey Stoyan, CliverSoft.com
//        http://cliversoft.com
//        stoyan@cliversoft.com
//        sergey.stoyan@gmail.com
//        03 January 2008
//Copyright: (C) 2008, Sergey Stoyan
//********************************************************************************************

using System;
using System.Drawing;
using System.Collections;
using System.Windows.Forms;
using System.Reflection;
using System.Diagnostics;

namespace Cliver
{
    /// <summary>
    /// Show MessageForm with predefined features
    /// </summary>
    public static class Message
    {
        static object lock_variable = new object();

        /// <summary>
        /// Defines how message boxes will be showed in multithreaded environment:
        /// TRUE: strongly in turn one after another even if sent from different threads;
        /// FALSE: simultaneously if sent from different threads - like .NET MessageBox does;
        /// </summary>
        public static bool ShowMessagesInTurn = true;

        /// <summary>
        /// Icon in the window header. By default it is the icon of the application.
        /// </summary>
        public static Icon WindowIcon = IconRoutines.ExtractIconFromLibrary(Application.ExecutablePath); //IconRoutines.ExtractIconFromLibrary(Application.ExecutablePath, IconRoutines.IconSize.Small);
        
        /// <summary>
        /// Caption that will be used by default. By default it is the application's product name.
        /// </summary>
        public static string Caption = Application.ProductName;

        /// <summary>
        /// Whether the message box is displayed in the Windows taskbar.
        /// </summary>
        public static bool ShowInTaskbar = true;

        /// <summary>
        /// Text for repeat-my-answer-in-the future checkbox
        /// </summary>
        static public string SilentBoxText = "Repeat my answer for such cases during this session";

        /// <summary>
        /// Default colors that buttons will be colored to.
        /// </summary>
        static public Color[] ButtonColors = new Color[4] { Color.LightGreen, Color.Salmon, Color.LightYellow, Color.LightBlue };

        /// <summary>
        /// Colors that buttons will be colored to in the first next message. If no need color, must be set to null. 
        /// Not thread-safe!
        /// </summary>
        static public Color[] NextTime_ButtonColors
        {
            set
            {
                if (value == null)
                    value = new Color[0];
                //NextTime_ButtonColors_queue.Enqueue(value);
                _NextTime_ButtonColors = value;
            }
            get
            {
                //return (Color[])NextTime_ButtonColors_queue.Dequeue();
                return _NextTime_ButtonColors;
            }
        }
        //static public System.Collections.Queue NextTime_ButtonColors_queue = new Queue();
        static Color[] _NextTime_ButtonColors = null;

        /// <summary>
        /// Owner of the first next message.
        /// Not thread-safe!
        /// </summary>
        static public Form NextTime_Owner = null;

        /// <summary>
        /// Show information message box.
        /// </summary>
        /// <param name="caption">box caption</param>
        /// <param name="icon">icon to be displayed beside message</param>
        /// <param name="message">message</param>
        public static void Ok(string caption, Icon icon, string message)
        {
            NextTime_ButtonColors = null;
            show(caption, icon, message, new string[1] { "OK" }, 0);
        }

        /// <summary>
        /// Show information message box with predefined caption.
        /// </summary>
        /// <param name="icon">icon to be displayed beside message</param>
        /// <param name="message">message</param>
        public static void Ok(Icon icon, string message)
        {
            Ok(Caption, icon, message);
        }

        /// <summary>
        /// Show error message box.
        /// </summary>
        /// <param name="e">exception</param>
        public static void Error(Exception e)
        {
            Ok(SystemIcons.Error, e.Message + "\n\n" + e.StackTrace);
        }

        /// <summary>
        /// Show error message box.
        /// </summary>
        /// <param name="message">message</param>
        public static void Error(string message)
        {
            Ok(SystemIcons.Error, message);
        }

        /// <summary>
        /// Show inform message box.
        /// </summary>
        /// <param name="message">message</param>
        public static void Inform(string message)
        {
            Ok(SystemIcons.Information, message);

        }

        /// <summary>
        /// Show "Yes|No" question box. 
        /// </summary>
        /// <param name="caption">box caption</param>
        /// <param name="icon">icon to be displayed beside message</param>
        /// <param name="question">question</param>
        /// <param name="default_yes">whether 'yes' button is selected</param>
        /// <returns>zero-based index of chosen answer</returns>
        public static bool YesNo(string caption, Icon icon, string question, bool default_yes)
        {
            return show(caption, icon, question, new string[2] { "Yes", "No" }, default_yes ? 0 : 1) == 0;

        }

        /// <summary>
        /// Show "YesNo" question box with predefined caption. 
        /// </summary>
        /// <param name="icon">icon to be displayed beside message</param>
        /// <param name="question">question</param>
        /// <returns>zero-based index of chosen answer</returns>
        public static bool YesNo(Icon icon, string question)
        {
            return YesNo(Caption, icon, question, true);
        }

        /// <summary>
        /// Show "Yes|No" question box with the question icon. 
        /// </summary>
        /// <param name="caption">box caption</param>
        /// <param name="question">question</param>
        /// <param name="default_yes">whether 'yes' button is selected</param>
        /// <returns>zero-based index of chosen answer</returns>
        public static bool YesNo(string caption, string question, bool default_yes)
        {
            return show(caption, SystemIcons.Question, question, new string[2] { "Yes", "No" }, default_yes ? 0 : 1) == 0;

        }

        /// <summary>
        /// Show "YesNo" question box with predefined caption and the question icon. 
        /// </summary>
        /// <param name="question">question</param>
        /// <returns>zero-based index of chosen answer</returns>
        public static bool YesNo(string question)
        {
            return YesNo(Caption, question, true);

        }

        /// <summary>
        /// Show "YesNo" question box with predefined caption and the question icon. 
        /// </summary>
        /// <param name="question">question</param>
        /// <param name="default_yes">whether 'yes' button is selected</param>
        /// <returns>zero-based index of chosen answer</returns>
        public static bool YesNo(string question, bool default_yes)
        {
            return YesNo(Caption, question, default_yes);

        }

        /// <summary>
        /// Show a question box with many answer cases and predefined caption.
        /// </summary>
        /// <param name="message">message</param>
        /// <param name="default_answer">zero-based index of default button</param>
        /// <param name="answers">possible answers</param>
        /// <returns>zero-based index of chosen answer</returns>
        public static int Ask(string message, int default_answer, params string[] answers)
        {
            return Show(Caption, SystemIcons.Question, message, default_answer, answers);

        }

        /// <summary>
        /// Show a question box with many answer cases, silent checkbox and predefined caption.
        /// </summary>
        /// <param name="silent_box">Whether this answer should be repeated automatically</param>
        /// <param name="message">message</param>
        /// <param name="default_answer">zero-based index of default button</param>
        /// <param name="answers">possible answers</param>
        /// <returns>zero-based index of chosen answer</returns>
        public static int Ask(out bool silent_box, string message, int default_answer, params string[] answers)
        {
            return Show(Caption, SystemIcons.Question, out silent_box, message, default_answer, answers);

        }

        /// <summary>
        /// Show a dialog box with many answer cases and default button colors.
        /// </summary>
        /// <param name="caption">box caption</param>
        /// <param name="icon">icon to be displayed beside message</param>
        /// <param name="message">message</param>
        /// <param name="default_answer">zero-based index of default button</param>
        /// <param name="answers">possible answers</param>
        /// <returns>zero-based index of chosen answer</returns>
        public static int Show(string caption, Icon icon, string message, int default_answer, params string[] answers)
        {
            return show(caption, icon, message, answers, default_answer);

        }

        /// <summary>
        /// Show a dialog box with many answer cases, default caption and button colors.
        /// </summary>
        /// <param name="icon">icon to be displayed beside message</param>
        /// <param name="message">message</param>
        /// <param name="default_answer">zero-based index of default button</param>
        /// <param name="answers">possible answers</param>
        /// <returns>zero-based index of chosen answer</returns>
        public static int Show(Icon icon, string message, int default_answer, params string[] answers)
        {
            return show(Caption, icon, message, answers, default_answer);

        }

        /// <summary>
        /// Show a dialog box with many answer cases, silent-answer checkbox and default button colors.
        /// </summary>
        /// <param name="caption">box caption</param>
        /// <param name="icon">icon to be displayed beside message</param>
        /// <param name="silent_box">whether this answer should be repeated automatically</param>
        /// <param name="message">message</param>
        /// <param name="default_answer">zero-based index of default button</param>
        /// <param name="answers">possible answers</param>
        /// <returns>zero-based index of chosen answer</returns>
        public static int Show(string caption, Icon icon, out bool silent_box, string message, int default_answer, params string[] answers)
        {
            return show(caption, icon, out silent_box, message, answers, default_answer);
        }

        /// <summary>
        /// Show a dialog box with many answer cases, silent-answer checkbox, default caption and button colors.
        /// </summary>
        /// <param name="icon">icon to be displayed beside message</param>
        /// <param name="silent_box">Whether this answer should be repeated automatically</param>
        /// <param name="message">message</param>
        /// <param name="default_answer">zero-based index of default button</param>
        /// <param name="answers">possible answers</param>
        /// <returns>zero-based index of chosen answer</returns>
        public static int Show(Icon icon, out bool silent_box, string message, int default_answer, params string[] answers)
        {
            return show(Caption, icon, out silent_box, message, answers, default_answer);
        }

        //************************************************************************************************************************
        //************************************************************************************************************************
        //BASE METHODS
        //************************************************************************************************************************
        //************************************************************************************************************************

        static void preset(MessageForm mf)
        {
            lock (lock_variable2)
            {
                mf.Icon = WindowIcon;
                mf.ShowInTaskbar = ShowInTaskbar;
                if (NextTime_Owner == null)
                {
                    mf.TopLevel = true;
                    mf.TopMost = true;
                }
                else
                    mf.Owner = NextTime_Owner;
            }
        }    

        static void postset()
        {
            lock (lock_variable2)
            {
                NextTime_Owner = null;
            }
        }

        static Color[] get_button_colors()
        {
            lock (lock_variable2)
            {
                Color[] colors = NextTime_ButtonColors;
                if (colors == null)
                    colors = ButtonColors;
                _NextTime_ButtonColors = null;
                return colors;
            }
        }

        static bool caller_is_gui_form()
        {
            lock (lock_variable2)
            {
                StackTrace stack = new StackTrace(true);
                foreach (StackFrame sf in stack.GetFrames())
                {
                    Type caller = sf.GetMethod().ReflectedType;
                    if (caller == typeof(Form))
                        return true;
                }
                return false;
            }
        }
        static object lock_variable2 = new object();

        static void show_blocking_dialog()
        {
            MessageForm mf2 = new MessageForm(
                               Caption,
                               "Please close all message boxes opened by this application, before using this form.",
                               null,
                               new string[1] { "OK" },
                               0,
                               null,
                               SystemIcons.Exclamation
                               );
            preset(mf2); 
            mf2.GetAnswer();
        }

        static int show(string caption, Icon icon, string message, string[] answers, int default_answer)
        {
            try
            {
                if (ShowMessagesInTurn)
                {
                    if (caller_is_gui_form())
                    {
                        while (!System.Threading.Monitor.TryEnter(lock_variable)) 
                            show_blocking_dialog();
                        //while (!System.Threading.Monitor.TryEnter(lock_variable))
                        //    Application.DoEvents();
                    }
                    else
                        System.Threading.Monitor.Enter(lock_variable);
                }

                MessageForm mf = new MessageForm(caption, message, get_button_colors(), answers, default_answer, null, icon);
                preset(mf);
                int i = mf.GetAnswer();
                postset();
                return i;
            }
            finally
            {
                if (ShowMessagesInTurn)
                    System.Threading.Monitor.Exit(lock_variable);
            }
        }

        static int show(string caption, Icon icon, out bool silent_box, string message, string[] answers, int default_answer)
        {
            try
            {
                if (ShowMessagesInTurn)
                {
                    if (caller_is_gui_form())
                    {
                        while (!System.Threading.Monitor.TryEnter(lock_variable))
                            show_blocking_dialog();
                        //while (!System.Threading.Monitor.TryEnter(lock_variable))
                        //    Application.DoEvents();
                    }
                    else
                        System.Threading.Monitor.Enter(lock_variable);
                }

                MessageForm mf = new MessageForm(caption, message, get_button_colors(), answers, default_answer, SilentBoxText, icon);
                preset(mf);
                int i = mf.GetAnswer();
                silent_box = mf.Silent;
                postset();
                return i;
            }
            finally
            {
                if (ShowMessagesInTurn)
                    System.Threading.Monitor.Exit(lock_variable);
            }
        }
    }
}

