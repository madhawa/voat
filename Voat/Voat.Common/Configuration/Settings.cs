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

using System.Collections.Generic;
using Voat.Common;

namespace Voat.Configuration
{
    public class Settings
    {
        #region AppSettings Accessors

        internal static Dictionary<string, object> configValues = new Dictionary<string, object>();

        public static bool IsVoatBranded
        {
            get
            {
                return SiteName.Equals("Voat", System.StringComparison.OrdinalIgnoreCase);
            }
        }

        public static bool AdsEnabled
        {
            get
            {
                return GetValue(CONFIGURATION.AdsEnabled, false);
            }
        }

        public static bool ApiKeyCreationEnabled
        {
            get
            {
                return GetValue(CONFIGURATION.ApiKeyCreationEnabled, false);
            }
        }

        public static bool CacheDisabled
        {
            get
            {
                return GetValue(CONFIGURATION.CacheDisabled, false);
            }
        }

        public static bool CaptchaDisabled
        {
            get
            {
                return GetValue(CONFIGURATION.CaptchaDisabled, false);
            }
        }
        public static bool ChatDisabled
        {
            get
            {
                return GetValue(CONFIGURATION.ChatDisabled, true);
            }
        }
        //public static Data.DataStoreType DataStore
        //{
        //    get
        //    {
        //        return GetValue(CONFIGURATION.DataStore, Data.DataStoreType.SqlServer);
        //    }
        //}

        public static int DailyCommentPostingQuota
        {
            get
            {
                return GetValue(CONFIGURATION.DailyCommentPostingQuota, 20);
            }
        }

        public static int DailyCommentPostingQuotaForNegativeScore
        {
            get
            {
                return GetValue(CONFIGURATION.DailyCommentPostingQuotaForNegativeScore, 10);
            }
        }

        public static int DailyCrossPostingQuota
        {
            get
            {
                return GetValue(CONFIGURATION.DailyCrossPostingQuota, 2);
            }
        }

        public static int DailyGlobalPostingQuota
        {
            get
            {
                return GetValue(CONFIGURATION.DailyGlobalPostingQuota, 5);
            }
        }

        public static int DailyPostingQuotaForNegativeScore
        {
            get
            {
                return GetValue(CONFIGURATION.DailyPostingQuotaForNegativeScore, 3);
            }
        }

        public static int DailyPostingQuotaPerSub
        {
            get
            {
                return GetValue(CONFIGURATION.DailyPostingQuotaPerSub, 10);
            }
        }

        public static int DailyVotingQuota
        {
            get
            {
                return GetValue(CONFIGURATION.DailyVotingQuota, 100);
            }
        }

        public static string DestinationPathAvatars
        {
            get
            {
                return GetValue(CONFIGURATION.DestinationPathAvatars, "~/Storage/Avatars");
            }
        }

        public static string DestinationPathThumbs
        {
            get
            {
                return GetValue(CONFIGURATION.DestinationPathThumbs, "~/Storage/Thumbs");
            }
        }
        public static string EmailAddress
        {
            get
            {
                return GetValue(CONFIGURATION.EmailAddress, "noreply@voat.co");
            }
        }
        public static string EmailServiceKey
        {
            get
            {
                return GetValue(CONFIGURATION.EmailServiceKey, "");
            }
        }

        public static bool ForceHTTPS
        {
            get
            {
                return GetValue(CONFIGURATION.ForceHTTPS, true);
            }
        }
        public static string FooterText
        {
            get
            {
                return GetValue(CONFIGURATION.FooterText, "");
            }
        }
        public static int HourlyCommentPostingQuota
        {
            get
            {
                return GetValue(CONFIGURATION.HourlyCommentPostingQuota, 10);
            }
        }

        public static int HourlyGlobalPostingQuota
        {
            get
            {
                return GetValue(CONFIGURATION.HourlyGlobalPostingQuota, 3);
            }
        }

        public static int HourlyPostingQuotaPerSub
        {
            get
            {
                return GetValue(CONFIGURATION.HourlyPostingQuotaPerSub, 3);
            }
        }

        public static bool LegacyApiEnabled
        {
            get
            {
                return GetValue(CONFIGURATION.LegacyApiEnabled, false);
            }
        }

        public static int MaxAllowedAccountsFromSingleIP
        {
            get
            {
                return GetValue(CONFIGURATION.MaxAllowedAccountsFromSingleIP, 100);
            }
        }

        public static int MaximumOwnedSets
        {
            get
            {
                return GetValue(CONFIGURATION.MaximumOwnedSets, 10);
            }
        }

        public static int MaximumOwnedSubs
        {
            get
            {
                return GetValue(CONFIGURATION.MaximumOwnedSubs, 10);
            }
        }

        public static int MaximumSetSubverseCount
        {
            get
            {
                return GetValue(CONFIGURATION.MaximumSetSubverseCount, 50);
            }
        }
        
        public static int MinimumAccountAgeInDaysForSubverseCreation
        {
            get
            {
                return GetValue(CONFIGURATION.MinimumAccountAgeInDaysForSubverseCreation, 30);
            }
        }
        public static int MinimumCommentPointsForSendingMessages
        {
            get
            {
                return GetValue(CONFIGURATION.MinimumCommentPointsForSendingMessages, 10);
            }
        }
        
        public static int MinimumCommentPointsForSubverseCreation
        {
            get
            {
                return GetValue(CONFIGURATION.MinimumCommentPointsForSubverseCreation, 10);
            }
        }
      

        public static int MinimumSubmissionPointsForSubverseCreation
        {
            get
            {
                return GetValue(CONFIGURATION.MinimumSubmissionPointsForSubverseCreation, 10);
            }
        }
        public static int MinimumCommentPointsForCaptchaMessaging
        {
            get
            {
                return GetValue(CONFIGURATION.MinimumCommentPointsForCaptchaMessaging, 100);
            }
        }
        public static int MinimumCommentPointsForCaptchaSubmission
        {
            get
            {
                return GetValue(CONFIGURATION.MinimumCommentPointsForCaptchaSubmission, 25);
            }
        }
        public static int MinimumCommentPointsForSendingChatMessages
        {
            get
            {
                return GetValue(CONFIGURATION.MinimumCommentPointsForSendingChatMessages, 100);
            }
        }

        public static Origin Origin
        {
            get
            {
                return GetValue(CONFIGURATION.Origin, Origin.Unknown);
            }
        }
        public static string RecaptchaPrivateKey
        {
            get
            {
                return GetValue(CONFIGURATION.RecaptchaPrivateKey, "");
            }
        }

        public static string RecaptchaPublicKey
        {
            get
            {
                return GetValue(CONFIGURATION.RecaptchaPublicKey, "");
            }
        }
        /// <summary>
        /// Will redirect incoming requests that don't match the site domain to the value specified in siteDomain
        /// </summary>
        public static bool RedirectToSiteDomain
        {
            get
            {
                return GetValue(CONFIGURATION.RedirectToSiteDomain, true);
            }
        }
        
        public static bool RegistrationDisabled
        {
            get
            {
                return GetValue(CONFIGURATION.RegistrationDisabled, false);
            }
        }
        public static bool SearchDisabled
        {
            get
            {
                return GetValue(CONFIGURATION.SearchDisabled, true);
            }
        }
        public static bool SetsDisabled
        {
            get
            {
                return GetValue(CONFIGURATION.SetsDisabled, true);
            }
        }
        public static bool SetCreationDisabled
        {
            get
            {
                return GetValue(CONFIGURATION.SetCreationDisabled, true);
            }
        }
        public static bool SignalRDisabled
        {
            get
            {
                return GetValue(CONFIGURATION.SignalRDisabled, true);
            }
        }

        public static string SiteDescription
        {
            get
            {
                return GetValue(CONFIGURATION.SiteDescription, "A community platform where you can have your say. No censorship.");
            }
        }

        public static string SiteDomain
        {
            get
            {
                return GetValue(CONFIGURATION.SiteDomain, "voat.co");
            }
        }

        public static string SiteKeywords
        {
            get
            {
                return GetValue(CONFIGURATION.SiteKeywords, "voat, voat.co, vote, submit, comment");
            }
        }

        public static string SiteLogo
        {
            get
            {
                return GetValue(CONFIGURATION.SiteLogo, "/Graphics/voat-logo.png");
            }
        }

        public static string SiteName
        {
            get
            {
                return GetValue(CONFIGURATION.SiteName, "Voat");
            }
        }

        public static string SiteSlogan
        {
            get
            {
                return GetValue(CONFIGURATION.SiteSlogan, "Voat - have your say");
            }
        }
        public static int SubverseUpdateTimeLockInHours
        {
            get
            {
                return GetValue(CONFIGURATION.SubverseUpdateTimeLockInHours, 48);
            }
        }
        
        public static bool UseContentDeliveryNetwork
        {
            get
            {
                return GetValue(CONFIGURATION.UseContentDeliveryNetwork, false);
            }
        }

        private static T GetValue<T>(string key, T defaultIfMissing)
        {
            if (configValues.ContainsKey(key))
            {
                var value = (T)configValues[key];
                //I'm NOT liking where this is going. And I forgot exactly what situation I originally wrote this for. As Fuzzy and Dan say, "It's a future person problem."
                if (typeof(T) == typeof(bool) || typeof(T) == typeof(int) || !value.IsDefault())
                {
                    return value;
                }
            }
            return defaultIfMissing;
        }
        #endregion AppSettings Accessors

    }
}