#region LICENSE

/*
    
    Copyright(c) Voat, Inc.

    This file is part of Voat.

    This source file is subject to version 3 of the GPL license,
    that is bundled with this package in the file LICENSE, and is
    available online at http://www.gnu.org/licenses/gpl-3.0.txt;
    you may not use this file except in compliance with the License.

    Software distributed under the License is distributed on an
    "AS IS" basis, WITHOUT WARRANTY OF ANY KIND, either express
    or implied. See the License for the specific language governing
    rights and limitations under the License.

    All Rights Reserved.

*/

#endregion LICENSE

using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Xml;
using Voat.Common;

namespace Voat.Configuration
{
    public static class CONFIGURATION
    {
        public const string AdsEnabled = "adsEnabled";
        public const string ApiKeyCreationEnabled = "apiKeyCreationEnabled";
        public const string CacheDisabled = "cacheDisabled";
        public const string CaptchaDisabled = "captchaDisabled";
        public const string ChatDisabled = "chatDisabled";

        public const string DataStore = "dataStore";

        public const string DailyCommentPostingQuota = "dailyCommentPostingQuota";
        public const string DailyCommentPostingQuotaForNegativeScore = "dailyCommentPostingQuotaForNegativeScore";
        public const string DailyCrossPostingQuota = "dailyCrossPostingQuota";
        public const string DailyGlobalPostingQuota = "dailyGlobalPostingQuota";
        public const string DailyPostingQuotaForNegativeScore = "dailyPostingQuotaForNegativeScore";
        public const string DailyPostingQuotaPerSub = "dailyPostingQuotaPerSub";
        public const string DailyVotingQuota = "dailyVotingQuota";
        public const string DestinationPathAvatars = "destinationPathAvatars";
        public const string DestinationPathThumbs = "destinationPathThumbs";

        public const string EmailAddress = "emailAddress";
        public const string EmailServiceKey = "emailServiceKey";
        public const string ForceHTTPS = "forceHTTPS";
        public const string FooterText = "footerText";
        public const string HourlyCommentPostingQuota = "hourlyCommentPostingQuota";
        public const string HourlyGlobalPostingQuota = "hourlyGlobalPostingQuota";
        public const string HourlyPostingQuotaPerSub = "hourlyPostingQuotaPerSub";
        public const string LegacyApiEnabled = "legacyApiEnabled";
        public const string MaxAllowedAccountsFromSingleIP = "maxAllowedAccountsFromSingleIP";
        
        public const string MaximumOwnedSubs = "maximumOwnedSubs";
        
        public const string MinimumAccountAgeInDaysForSubverseCreation = "minimumAccountAgeInDaysForSubverseCreation";
        public const string MinimumCommentPointsForSubverseCreation = "minimumCommentPointsForSubverseCreation";
        public const string MinimumSubmissionPointsForSubverseCreation = "minimumSubmissionPointsForSubverseCreation";
        public const string MinimumCommentPointsForCaptchaSubmission = "minimumCommentPointsForCaptchaSubmission";
        public const string MinimumCommentPointsForCaptchaMessaging = "minimumCommentPointsForCaptchaMessaging";
        public const string MinimumCommentPointsForSendingMessages = "minimumCommentPointsForSendingMessages";
        public const string MinimumCommentPointsForSendingChatMessages = "minimumCommentPointsForSendingChatMessages";

        public const string RuntimeState = "runtimeState";
        public const string RecaptchaPrivateKey = "recaptchaPrivateKey";
        public const string RedirectToSiteDomain = "redirectToSiteDomain";
        public const string RecaptchaPublicKey = "recaptchaPublicKey";
        public const string RegistrationDisabled = "registrationDisabled";

        //Sets
        public const string SetsDisabled = "setsDisabled";
        public const string SetCreationDisabled = "setCreationDisabled";
        public const string MaximumOwnedSets = "maximumOwnedSets";
        public const string MaximumSetSubverseCount = "maximumSetSubverseCount";

        public const string SignalRDisabled = "signalrDisabled";
        public const string SiteDescription = "siteDescription";
        public const string SiteDisabled = "siteDisabled";
        public const string SiteDomain = "siteDomain";
        public const string SiteKeywords = "siteKeywords";
        public const string SiteLogo = "siteLogo";
        public const string SiteName = "siteName";
        public const string SiteSlogan = "siteSlogan";
        public const string Origin = "origin";
        public const string SearchDisabled = "searchDisabled";

        public const string SubverseUpdateTimeLockInHours = "subverseUpdateTimeLockInHours";
        

        public const string UseContentDeliveryNetwork = "useContentDeliveryNetwork";
    }

    //CORE_PORT: Figure out how to port the "Live Monitoring" we previously implemented.
    public class LiveConfigurationManager
    {
        private static FileSystemWatcher _thewatchmen;

        private static FileSystemWatcher Watcher
        {
            get
            {
                if (_thewatchmen == null)
                {
                    lock (typeof(LiveConfigurationManager))
                    {
                        if (_thewatchmen == null)
                        {
                            //CORE_PORT: HttpContext not available 
                            throw new NotImplementedException("Core Port: HttpContext access");
                            /*
                            if (HttpContext.Current != null)
                            {
                                _thewatchmen = new FileSystemWatcher(HttpContext.Current.Server.MapPath("~/"), "Web.config.live");
                            }
                            else
                            {
                                _thewatchmen = new FileSystemWatcher(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Web.config.live");
                            }

                            _thewatchmen.NotifyFilter = NotifyFilters.LastWrite;

                            _thewatchmen.Changed += (object sender, FileSystemEventArgs e) =>
                            {
                                Reload(e.FullPath);
                            };
                            */
                        }
                    }
                }
                return _thewatchmen;
            }
        }

        //Core_Port: Config Load Changes
        public static void Reload(IConfigurationSection section)
        {
            if (section != null)
            {
                SetValueIfPresent<string>(CONFIGURATION.RecaptchaPublicKey, section[CONFIGURATION.RecaptchaPublicKey]);
                SetValueIfPresent<string>(CONFIGURATION.RecaptchaPrivateKey, section[CONFIGURATION.RecaptchaPrivateKey]);

                SetValueIfPresent<string>(CONFIGURATION.EmailAddress, section[CONFIGURATION.EmailAddress]);
                SetValueIfPresent<string>(CONFIGURATION.EmailServiceKey, section[CONFIGURATION.EmailServiceKey]);
                SetValueIfPresent<string>(CONFIGURATION.SiteName, section[CONFIGURATION.SiteName]);
                SetValueIfPresent<string>(CONFIGURATION.SiteSlogan, section[CONFIGURATION.SiteSlogan]);
                SetValueIfPresent<string>(CONFIGURATION.SiteDescription, section[CONFIGURATION.SiteDescription]);
                SetValueIfPresent<string>(CONFIGURATION.SiteKeywords, section[CONFIGURATION.SiteKeywords]);
                SetValueIfPresent<string>(CONFIGURATION.SiteLogo, section[CONFIGURATION.SiteLogo]);
                SetValueIfPresent<string>(CONFIGURATION.DestinationPathAvatars, section[CONFIGURATION.DestinationPathAvatars]);
                SetValueIfPresent<string>(CONFIGURATION.DestinationPathThumbs, section[CONFIGURATION.DestinationPathThumbs]);
                SetValueIfPresent<string>(CONFIGURATION.FooterText, section[CONFIGURATION.FooterText]);
                
                SetValueIfPresent<int>(CONFIGURATION.MaximumOwnedSubs, section[CONFIGURATION.MaximumOwnedSubs]);
                
                SetValueIfPresent<int>(CONFIGURATION.DailyPostingQuotaPerSub, section[CONFIGURATION.DailyPostingQuotaPerSub]);
                SetValueIfPresent<int>(CONFIGURATION.HourlyPostingQuotaPerSub, section[CONFIGURATION.HourlyPostingQuotaPerSub]);
                SetValueIfPresent<int>(CONFIGURATION.HourlyGlobalPostingQuota, section[CONFIGURATION.HourlyGlobalPostingQuota]);
                SetValueIfPresent<int>(CONFIGURATION.DailyVotingQuota, section[CONFIGURATION.DailyVotingQuota]);
                SetValueIfPresent<int>(CONFIGURATION.DailyCrossPostingQuota, section[CONFIGURATION.DailyCrossPostingQuota]);
                SetValueIfPresent<int>(CONFIGURATION.DailyPostingQuotaForNegativeScore, section[CONFIGURATION.DailyPostingQuotaForNegativeScore]);
                SetValueIfPresent<int>(CONFIGURATION.DailyGlobalPostingQuota, section[CONFIGURATION.DailyGlobalPostingQuota]);
                SetValueIfPresent<int>(CONFIGURATION.DailyCommentPostingQuotaForNegativeScore, section[CONFIGURATION.DailyCommentPostingQuotaForNegativeScore]);
                SetValueIfPresent<int>(CONFIGURATION.DailyCommentPostingQuota, section[CONFIGURATION.DailyCommentPostingQuota]);
                SetValueIfPresent<int>(CONFIGURATION.HourlyCommentPostingQuota, section[CONFIGURATION.HourlyCommentPostingQuota]);
                SetValueIfPresent<int>(CONFIGURATION.MaxAllowedAccountsFromSingleIP, section[CONFIGURATION.MaxAllowedAccountsFromSingleIP]);

                SetValueIfPresent<int>(CONFIGURATION.MinimumAccountAgeInDaysForSubverseCreation, section[CONFIGURATION.MinimumAccountAgeInDaysForSubverseCreation]);
                SetValueIfPresent<int>(CONFIGURATION.MinimumCommentPointsForSubverseCreation, section[CONFIGURATION.MinimumCommentPointsForSubverseCreation]);
                SetValueIfPresent<int>(CONFIGURATION.MinimumSubmissionPointsForSubverseCreation, section[CONFIGURATION.MinimumSubmissionPointsForSubverseCreation]);
                SetValueIfPresent<int>(CONFIGURATION.MinimumCommentPointsForCaptchaMessaging, section[CONFIGURATION.MinimumCommentPointsForCaptchaMessaging]);
                SetValueIfPresent<int>(CONFIGURATION.MinimumCommentPointsForCaptchaSubmission, section[CONFIGURATION.MinimumCommentPointsForCaptchaSubmission]);
                SetValueIfPresent<int>(CONFIGURATION.MinimumCommentPointsForSendingMessages, section[CONFIGURATION.MinimumCommentPointsForSendingMessages]);
                SetValueIfPresent<int>(CONFIGURATION.MinimumCommentPointsForSendingChatMessages, section[CONFIGURATION.MinimumCommentPointsForSendingChatMessages]);



                SetValueIfPresent<bool>(CONFIGURATION.ForceHTTPS, section[CONFIGURATION.ForceHTTPS]);
                SetValueIfPresent<bool>(CONFIGURATION.SignalRDisabled, section[CONFIGURATION.SignalRDisabled]);

                //Sets
                SetValueIfPresent<bool>(CONFIGURATION.SetsDisabled, section[CONFIGURATION.SetsDisabled]);
                SetValueIfPresent<bool>(CONFIGURATION.SetCreationDisabled, section[CONFIGURATION.SetCreationDisabled]);
                SetValueIfPresent<int>(CONFIGURATION.MaximumSetSubverseCount, section[CONFIGURATION.MaximumSetSubverseCount]);
                SetValueIfPresent<int>(CONFIGURATION.MaximumOwnedSets, section[CONFIGURATION.MaximumOwnedSets]);


                SetValueIfPresent<bool>(CONFIGURATION.CacheDisabled, section[CONFIGURATION.CacheDisabled]);
                SetValueIfPresent<bool>(CONFIGURATION.ChatDisabled, section[CONFIGURATION.ChatDisabled]);
                SetValueIfPresent<bool>(CONFIGURATION.RegistrationDisabled, section[CONFIGURATION.RegistrationDisabled]);
                SetValueIfPresent<bool>(CONFIGURATION.RedirectToSiteDomain, section[CONFIGURATION.RedirectToSiteDomain]);
                SetValueIfPresent<bool>(CONFIGURATION.UseContentDeliveryNetwork, section[CONFIGURATION.UseContentDeliveryNetwork]);

                SetValueIfPresent<bool>(CONFIGURATION.AdsEnabled, section[CONFIGURATION.AdsEnabled]);
                SetValueIfPresent<string>(CONFIGURATION.SiteDomain, section[CONFIGURATION.SiteDomain]);
                SetValueIfPresent<bool>(CONFIGURATION.LegacyApiEnabled, section[CONFIGURATION.LegacyApiEnabled]);

                SetValueIfPresent<bool>(CONFIGURATION.ApiKeyCreationEnabled, section[CONFIGURATION.ApiKeyCreationEnabled]);
                SetValueIfPresent<bool>(CONFIGURATION.CaptchaDisabled, section[CONFIGURATION.CaptchaDisabled]);
                SetValueIfPresent<bool>(CONFIGURATION.SearchDisabled, section[CONFIGURATION.SearchDisabled]);
                SetValueIfPresent<int>(CONFIGURATION.SubverseUpdateTimeLockInHours, section[CONFIGURATION.SubverseUpdateTimeLockInHours]);

                SetValueIfPresent<DataStoreType>(CONFIGURATION.DataStore, section[CONFIGURATION.DataStore]);
                SetValueIfPresent<Origin>(CONFIGURATION.Origin, section[CONFIGURATION.Origin]);

                //HACK ATTACK
                //CORE_PORT: Caused Error Because Config Set Isn't Fully Ported
                //CacheHandler.Instance.CacheEnabled = !Settings.CacheDisabled;
            }
        }

        public static void Start()
        {
            Watcher.EnableRaisingEvents = true;
        }

        public static void Stop()
        {
            Watcher.EnableRaisingEvents = false;
        }
        //private static void Reload(string fullFilePath)
        //{
        //    if (File.Exists(fullFilePath))
        //    {
        //        try
        //        {
        //            XmlDocument doc = new XmlDocument();
        //            doc.Load(fullFilePath);
        //            XmlNodeList nodes = doc.SelectNodes("/configuration/appSettings/add");

        //            foreach (XmlNode node in nodes)
        //            {
        //                string key = node.Attributes["key"].Value;
        //                //add condition for RuntimeState as it has it's own handler
        //                if (String.Equals(key, CONFIGURATION.RuntimeState, StringComparison.OrdinalIgnoreCase))
        //                {
        //                    RuntimeState.Refresh(node.Attributes["value"].Value);
        //                }
        //                else
        //                {
        //                    SetValueIfPresent<bool>(node.Attributes["key"].Value, node.Attributes["value"].Value, true);
        //                }
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            EventLogger.Log(ex);
        //        }
        //    }
        //}
        private static void SetValueIfPresent<T>(string key, string value, bool updateOnly = false)
        {
            if (!String.IsNullOrEmpty(key) && value != null)
            {
                object saveValue = null;
                if (typeof(T) == typeof(string))
                {
                    saveValue = value;
                }
                else if (typeof(T) == typeof(bool))
                {
                    //seperate logic for bool because we want accuracy for true settings
                    bool conValue = false;
                    if (!bool.TryParse(value, out conValue))
                    {
                        conValue = false;
                    }
                    saveValue = conValue;
                }
                else if (typeof(T).IsEnum)
                {
                    T conValue = (T)Enum.Parse(typeof(T), value, true);
                    saveValue = conValue;
                }
                else
                {
                    T conValue = (T)Convert.ChangeType(value, typeof(T));
                    saveValue = conValue;
                }
                if (!updateOnly || (updateOnly && Settings.configValues.ContainsKey(key)))
                {
                    Settings.configValues[key] = saveValue;
                }
            }
        }
    }
}