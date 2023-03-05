using Microsoft.AspNetCore.Authentication;

namespace FormAfzarHandler.Models {
#nullable disable

    public class Hubspot {
        public class Contact {

            public class Create {
                public class Req {

                    public Properties properties { get; set; }

                    public class Properties {
                        public string company { get; set; }
                        public string email { get; set; }
                        public string firstname { get; set; }
                        public string lastname { get; set; }
                        public string phone { get; set; }
                        public string website { get; set; }
                    }

                }

                public class Resp {

                        public string status { get; set; }
                        public string message { get; set; }
                        public string correlationId { get; set; }
                        public string category { get; set; }


                        public string id { get; set; }
                        public Properties properties { get; set; }
                        public DateTime createdAt { get; set; }
                        public DateTime updatedAt { get; set; }
                        public bool archived { get; set; }

                    public class Properties {
                        public object company { get; set; }
                        public DateTime createdate { get; set; }
                        public string email { get; set; }
                        public string firstname { get; set; }
                        public string hs_all_contact_vids { get; set; }
                        public string hs_email_domain { get; set; }
                        public string hs_is_contact { get; set; }
                        public string hs_is_unworked { get; set; }
                        public DateTime hs_lifecyclestage_lead_date { get; set; }
                        public string hs_object_id { get; set; }
                        public string hs_pipeline { get; set; }
                        public string hs_searchable_calculated_phone_number { get; set; }
                        public DateTime lastmodifieddate { get; set; }
                        public object lastname { get; set; }
                        public string lifecyclestage { get; set; }
                        public string phone { get; set; }
                        public object website { get; set; }

                        public string total_revenue { get; set; }
                    }

                }



            }

       
        }

        public class Deal {

            public class Create {

                public class Req {

                    public Properties properties { get; set; }

                    public class Properties {

                        public string amount { get; set; }
                        
                        public string dealname { get; set; }
                        public string dealstage { get; set; }
                        public string hubspot_owner_id { get; set; }
                        public string pipeline { get; set; }


                    }
                }

                public class Resp {

                    public string id { get; set; }
                    public Properties properties { get; set; }
                    public DateTime createdAt { get; set; }
                    public DateTime updatedAt { get; set; }
                    public bool archived { get; set; }


                    public class Properties {
                        public string amount { get; set; }
                        public string amount_in_home_currency { get; set; }
                        public DateTime closedate { get; set; }
                        public DateTime createdate { get; set; }
                        public string days_to_close { get; set; }
                        public string dealname { get; set; }
                        public string dealstage { get; set; }
                        public string hs_closed_amount { get; set; }
                        public string hs_closed_amount_in_home_currency { get; set; }
                        public DateTime hs_createdate { get; set; }
                        public string hs_deal_stage_probability_shadow { get; set; }
                        public string hs_forecast_amount { get; set; }
                        public string hs_is_closed { get; set; }
                        public string hs_is_closed_won { get; set; }
                        public string hs_is_deal_split { get; set; }
                        public DateTime hs_lastmodifieddate { get; set; }
                        public string hs_object_id { get; set; }
                        public string hs_projected_amount { get; set; }
                        public string hs_projected_amount_in_home_currency { get; set; }
                        public string pipeline { get; set; }
                    }

                }
            }
        }
    }

}


