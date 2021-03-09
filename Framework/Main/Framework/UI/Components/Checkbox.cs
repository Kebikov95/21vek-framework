using AutomationFramework.Main.Framework.Browser;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutomationFramework.Main.Framework.UI.Components
{
    class Checkbox : CommonPageElement
    {
    public Checkbox(By by) : base(by) { }

    public void SetSelected(bool selected)
    {
        if (selected)
        {
            if (!isSelected())
            {
                BrowserManager.GetInstance().Click(by);
            }
        }
        else
        {
            if (isSelected())
            {
                BrowserManager.GetInstance().Click(by);
            }
        }
    }

    public bool isSelected()
    {
        WaitForElementIsVisible(by);
        return BrowserManager.GetInstance().IsSelected(by);
    }
}
}
