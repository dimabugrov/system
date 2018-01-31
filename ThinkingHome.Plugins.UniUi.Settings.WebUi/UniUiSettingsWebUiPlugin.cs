﻿using ThinkingHome.Core.Plugins;
using ThinkingHome.Plugins.WebUi.Apps;
using ThinkingHome.Plugins.WebUi.Attributes;

namespace ThinkingHome.Plugins.UniUi.Settings.WebUi
{
    [AppSection(SectionType.System, "Dashboards", "/static/uniui/settings/web-ui/dashboard-list.js",
        "ThinkingHome.Plugins.UniUi.Settings.WebUi.Resources.dashboard-list.js", Icon = "th")]
    // [CssResource("/static/cron/web-ui/styles.css", "ThinkingHome.Plugins.UniUi.Settings.WebUi.Resources.styles.css", AutoLoad = true)]

    // templates
    [TemplateResource("/static/uniui/settings/web-ui/dashboard-list.tpl", "ThinkingHome.Plugins.UniUi.Settings.WebUi.Resources.dashboard-list.tpl")]
    [TemplateResource("/static/uniui/settings/web-ui/dashboard-list-item.tpl", "ThinkingHome.Plugins.UniUi.Settings.WebUi.Resources.dashboard-list-item.tpl")]

    // i18n
    // [HttpLocalizationResource("/static/uniui/settings/web-ui/lang.json")]

    public class UniUiSettingsWebUiPlugin : PluginBase
    {
    }
}