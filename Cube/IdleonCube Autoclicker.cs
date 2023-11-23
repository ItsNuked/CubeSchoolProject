/*
using System;
using System.Runtime.InteropServices;

//Importi (to add hotkeys/mouseclicks ker jih c# nima by default)
[DllImport("user32.dll")]
static extern void mouse_event(uint dwFlags, uint dx, uint dy, uint dwData, IntPtr dwExtraInfo);    //klik miške

[DllImport("user32.dll")]   
static extern short GetAsyncKeyState(uint vKey); */ //hotkey (ALERT=Program ni delu doklr nisva kle dala (uint vKey) namesto (int vKey).
                                                 //Program je javlu da ne more convertat int v uint (ker ma int tud negativne uint pa same pozitivne). To je nama delal, yt man je meu pa int. 
//Class variables
/*
const uint LEFTDOWN =0x02; //left mouse button goes down
const uint LEFTUP =0x04;   //left mouse button goes up
const uint HOTKEY =0x55;  //Keybind (U) is pressed i guess

bool enableClicker = false; //Preden pritisneva hotkey je ugasnjen (da ti ne naziga skos pa tkoj ko zazenes code)
int clickInterval =5; //na koliko milisekund caka med kliki
*/

//main loop for autoclicker
/*
while (true)
{
    if (GetAsyncKeyState(HOTKEY)<0)             //Check ce se drzi down hotkey (ce je less then zero je down)
    {
        enableClicker = !enableClicker;           //če je the if stavek true, negacija in invertas true/false of the enableClicker bool
        Thread.Sleep(300);                        //Sleep-a between hotkey clicks so ig u dont click it twice by accident? Seems so
    }
    if (enableClicker)
    {
        MouseClick();                             //Kliče funkcijo MouseClick. Izgleda kot da v funkciji MouseClick koda izvede še funkcijo 
    }                                             //mouse_event 2x, in sicer z dwFlags dx dy set to 0. (to not change position of click).

    Thread.Sleep(clickInterval);                  //.sleep makes the program wait clickerInterval miliseconds, kar sva definala v line 18.
}
*/
//Create mouse click
/* 
void MouseClick()
{
mouse_event(LEFTDOWN,0,0,0,IntPtr.Zero); //we don't need anymore information than the leftdown constant.
mouse_event(LEFTUP,0,0,0,IntPtr.Zero); //press down, then up
}
*/