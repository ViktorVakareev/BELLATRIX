﻿// <copyright file="WebSettings.cs" company="Automate The Planet Ltd.">
// Copyright 2021 Automate The Planet Ltd.
// Licensed under the Apache License, Version 2.0 (the "License");
// You may not use this file except in compliance with the License.
// You may obtain a copy of the License at http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// </copyright>
// <author>Anton Angelov</author>
// <site>https://bellatrix.solutions/</site>
namespace Bellatrix.Web
{
    public sealed class WebSettings
    {
        public bool AddUrlToBddLogging { get; set; }
        public bool ShouldAutomaticallyScrollToVisible { get; set; }
        public bool ShouldWaitUntilReadyOnElementFound { get; set; }
        public bool ShouldWaitForAngular { get; set; }
        public bool ShouldHighlightElements { get; set; }
        public bool FullPageScreenshotsEnabled { get; set; }
        public bool ShouldCaptureHttpTraffic { get; set; }
        public string PathToSslCertificate { get; set; }
        public bool IsParallelExecutionEnabled { get; set; }
        public bool ShouldCheckForJavaScriptErrors { get; set; }
        public TimeoutSettings TimeoutSettings { get; set; }
        public ExecutionSettings ExecutionSettings { get; set; }
    }
}