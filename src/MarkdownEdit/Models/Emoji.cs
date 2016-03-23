﻿using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace MarkdownEdit.Models
{
    internal static class Emoji
    {
        private static readonly Regex Scan = new Regex(@":[^\s]+:", RegexOptions.Compiled);

        public static string ConvertEmojis(this string markdown, CommonMark.Syntax.Block ast)
        {
            return Scan.Replace(markdown, match =>
            {
                if (!AbstractSyntaxTree.PositionSafeForSmartLink(ast, match.Index, match.Length)) return match.Value;
                string value;
                return Emojis.TryGetValue(match.Value, out value)
                    ? $"<i class=\"_sprite {value}\"/>"
                    : match.Value;
            });
        }

        private static readonly Dictionary<string, string> Emojis = new Dictionary<string, string>
        {
            {":+1:", "_1f44d"},
            {":-1:", "_1f44e"},
            {":100:", "_1f4af"},
            {":1234:", "_1f522"},
            {":8ball:", "_1f3b1"},
            {":a:", "_1f170"},
            {":ab:", "_1f18e"},
            {":abc:", "_1f524"},
            {":abcd:", "_1f521"},
            {":accept:", "_1f251"},
            {":aerial_tramway:", "_1f6a1"},
            {":airplane:", "_2708"},
            {":alarm_clock:", "_23f0"},
            {":alien:", "_1f47d"},
            {":ambulance:", "_1f691"},
            {":anchor:", "_2693"},
            {":angel:", "_1f47c"},
            {":anger:", "_1f4a2"},
            {":angry:", "_1f620"},
            {":anguished:", "_1f627"},
            {":ant:", "_1f41c"},
            {":apple:", "_1f34e"},
            {":aquarius:", "_2652"},
            {":aries:", "_2648"},
            {":arrow_backward:", "_25c0"},
            {":arrow_double_down:", "_23ec"},
            {":arrow_double_up:", "_23eb"},
            {":arrow_down:", "_2b07"},
            {":arrow_down_small:", "_1f53d"},
            {":arrow_forward:", "_25b6"},
            {":arrow_heading_down:", "_2935"},
            {":arrow_heading_up:", "_2934"},
            {":arrow_left:", "_2b05"},
            {":arrow_lower_left:", "_2199"},
            {":arrow_lower_right:", "_2198"},
            {":arrow_right:", "_27a1"},
            {":arrow_right_hook:", "_21aa"},
            {":arrow_up:", "_2b06"},
            {":arrow_up_down:", "_2195"},
            {":arrow_up_small:", "_1f53c"},
            {":arrow_upper_left:", "_2196"},
            {":arrow_upper_right:", "_2197"},
            {":arrows_clockwise:", "_1f503"},
            {":arrows_counterclockwise:", "_1f504"},
            {":art:", "_1f3a8"},
            {":articulated_lorry:", "_1f69b"},
            {":astonished:", "_1f632"},
            {":athletic_shoe:", "_1f45f"},
            {":atm:", "_1f3e7"},
            {":b:", "_1f171"},
            {":baby:", "_1f476"},
            {":baby_bottle:", "_1f37c"},
            {":baby_chick:", "_1f424"},
            {":baby_symbol:", "_1f6bc"},
            {":back:", "_1f519"},
            {":baggage_claim:", "_1f6c4"},
            {":balloon:", "_1f388"},
            {":ballot_box_with_check:", "_2611"},
            {":bamboo:", "_1f38d"},
            {":banana:", "_1f34c"},
            {":bangbang:", "_203c"},
            {":bank:", "_1f3e6"},
            {":bar_chart:", "_1f4ca"},
            {":barber:", "_1f488"},
            {":baseball:", "_26be"},
            {":basketball:", "_1f3c0"},
            {":bath:", "_1f6c0"},
            {":bathtub:", "_1f6c1"},
            {":battery:", "_1f50b"},
            {":bear:", "_1f43b"},
            {":bee:", "_1f41d"},
            {":beer:", "_1f37a"},
            {":beers:", "_1f37b"},
            {":beetle:", "_1f41e"},
            {":beginner:", "_1f530"},
            {":bell:", "_1f514"},
            {":bento:", "_1f371"},
            {":bicyclist:", "_1f6b4"},
            {":bike:", "_1f6b2"},
            {":bikini:", "_1f459"},
            {":bird:", "_1f426"},
            {":birthday:", "_1f382"},
            {":black_circle:", "_26ab"},
            {":black_joker:", "_1f0cf"},
            {":black_large_square:", "_2b1b"},
            {":black_medium_small_square:", "_25fe"},
            {":black_medium_square:", "_25fc"},
            {":black_nib:", "_2712"},
            {":black_small_square:", "_25aa"},
            {":black_square_button:", "_1f532"},
            {":blossom:", "_1f33c"},
            {":blowfish:", "_1f421"},
            {":blue_book:", "_1f4d8"},
            {":blue_car:", "_1f699"},
            {":blue_heart:", "_1f499"},
            {":blush:", "_1f60a"},
            {":boar:", "_1f417"},
            {":boat:", "_26f5"},
            {":bomb:", "_1f4a3"},
            {":book:", "_1f4d6"},
            {":bookmark:", "_1f516"},
            {":bookmark_tabs:", "_1f4d1"},
            {":books:", "_1f4da"},
            {":boom:", "_1f4a5"},
            {":boot:", "_1f462"},
            {":bouquet:", "_1f490"},
            {":bow:", "_1f647"},
            {":bowling:", "_1f3b3"},
            {":bowtie:", "_bowtie"},
            {":boy:", "_1f466"},
            {":bread:", "_1f35e"},
            {":bride_with_veil:", "_1f470"},
            {":bridge_at_night:", "_1f309"},
            {":briefcase:", "_1f4bc"},
            {":broken_heart:", "_1f494"},
            {":bug:", "_1f41b"},
            {":bulb:", "_1f4a1"},
            {":bullettrain_front:", "_1f685"},
            {":bullettrain_side:", "_1f684"},
            {":bus:", "_1f68c"},
            {":busstop:", "_1f68f"},
            {":bust_in_silhouette:", "_1f464"},
            {":busts_in_silhouette:", "_1f465"},
            {":cactus:", "_1f335"},
            {":cake:", "_1f370"},
            {":calendar:", "_1f4c6"},
            {":calling:", "_1f4f2"},
            {":camel:", "_1f42b"},
            {":camera:", "_1f4f7"},
            {":cancer:", "_264b"},
            {":candy:", "_1f36c"},
            {":capital_abcd:", "_1f520"},
            {":capricorn:", "_2651"},
            {":car:", "_1f697"},
            {":card_index:", "_1f4c7"},
            {":carousel_horse:", "_1f3a0"},
            {":cat:", "_1f431"},
            {":cat2:", "_1f408"},
            {":cd:", "_1f4bf"},
            {":chart:", "_1f4b9"},
            {":chart_with_downwards_trend:", "_1f4c9"},
            {":chart_with_upwards_trend:", "_1f4c8"},
            {":checkered_flag:", "_1f3c1"},
            {":cherries:", "_1f352"},
            {":cherry_blossom:", "_1f338"},
            {":chestnut:", "_1f330"},
            {":chicken:", "_1f414"},
            {":children_crossing:", "_1f6b8"},
            {":chocolate_bar:", "_1f36b"},
            {":christmas_tree:", "_1f384"},
            {":church:", "_26ea"},
            {":cinema:", "_1f3a6"},
            {":circus_tent:", "_1f3aa"},
            {":city_sunrise:", "_1f307"},
            {":city_sunset:", "_1f306"},
            {":cl:", "_1f191"},
            {":clap:", "_1f44f"},
            {":clapper:", "_1f3ac"},
            {":clipboard:", "_1f4cb"},
            {":clock1:", "_1f550"},
            {":clock10:", "_1f559"},
            {":clock1030:", "_1f565"},
            {":clock11:", "_1f55a"},
            {":clock1130:", "_1f566"},
            {":clock12:", "_1f55b"},
            {":clock1230:", "_1f567"},
            {":clock130:", "_1f55c"},
            {":clock2:", "_1f551"},
            {":clock230:", "_1f55d"},
            {":clock3:", "_1f552"},
            {":clock330:", "_1f55e"},
            {":clock4:", "_1f553"},
            {":clock430:", "_1f55f"},
            {":clock5:", "_1f554"},
            {":clock530:", "_1f560"},
            {":clock6:", "_1f555"},
            {":clock630:", "_1f561"},
            {":clock7:", "_1f556"},
            {":clock730:", "_1f562"},
            {":clock8:", "_1f557"},
            {":clock830:", "_1f563"},
            {":clock9:", "_1f558"},
            {":clock930:", "_1f564"},
            {":closed_book:", "_1f4d5"},
            {":closed_lock_with_key:", "_1f510"},
            {":closed_umbrella:", "_1f302"},
            {":cloud:", "_2601"},
            {":clubs:", "_2663"},
            {":cn:", "_1f1e8-1f1f3"},
            {":cocktail:", "_1f378"},
            {":coffee:", "_2615"},
            {":cold_sweat:", "_1f630"},
            {":collision:", "_1f4a5"},
            {":computer:", "_1f4bb"},
            {":confetti_ball:", "_1f38a"},
            {":confounded:", "_1f616"},
            {":confused:", "_1f615"},
            {":congratulations:", "_3297"},
            {":construction:", "_1f6a7"},
            {":construction_worker:", "_1f477"},
            {":convenience_store:", "_1f3ea"},
            {":cookie:", "_1f36a"},
            {":cool:", "_1f192"},
            {":cop:", "_1f46e"},
            {":copyright:", "_00a9"},
            {":corn:", "_1f33d"},
            {":couple:", "_1f46b"},
            {":couple_with_heart:", "_1f491"},
            {":couplekiss:", "_1f48f"},
            {":cow:", "_1f42e"},
            {":cow2:", "_1f404"},
            {":credit_card:", "_1f4b3"},
            {":crescent_moon:", "_1f319"},
            {":crocodile:", "_1f40a"},
            {":crossed_flags:", "_1f38c"},
            {":crown:", "_1f451"},
            {":cry:", "_1f622"},
            {":crying_cat_face:", "_1f63f"},
            {":crystal_ball:", "_1f52e"},
            {":cupid:", "_1f498"},
            {":curly_loop:", "_27b0"},
            {":currency_exchange:", "_1f4b1"},
            {":curry:", "_1f35b"},
            {":custard:", "_1f36e"},
            {":customs:", "_1f6c3"},
            {":cyclone:", "_1f300"},
            {":dancer:", "_1f483"},
            {":dancers:", "_1f46f"},
            {":dango:", "_1f361"},
            {":dart:", "_1f3af"},
            {":dash:", "_1f4a8"},
            {":date:", "_1f4c5"},
            {":de:", "_1f1e9-1f1ea"},
            {":deciduous_tree:", "_1f333"},
            {":department_store:", "_1f3ec"},
            {":diamond_shape_with_a_dot_inside:", "_1f4a0"},
            {":diamonds:", "_2666"},
            {":disappointed:", "_1f61e"},
            {":disappointed_relieved:", "_1f625"},
            {":dizzy:", "_1f4ab"},
            {":dizzy_face:", "_1f635"},
            {":do_not_litter:", "_1f6af"},
            {":dog:", "_1f436"},
            {":dog2:", "_1f415"},
            {":dollar:", "_1f4b5"},
            {":dolls:", "_1f38e"},
            {":dolphin:", "_1f42c"},
            {":door:", "_1f6aa"},
            {":doughnut:", "_1f369"},
            {":dragon:", "_1f409"},
            {":dragon_face:", "_1f432"},
            {":dress:", "_1f457"},
            {":dromedary_camel:", "_1f42a"},
            {":droplet:", "_1f4a7"},
            {":dvd:", "_1f4c0"},
            {":e-mail:", "_1f4e7"},
            {":ear:", "_1f442"},
            {":ear_of_rice:", "_1f33e"},
            {":earth_africa:", "_1f30d"},
            {":earth_americas:", "_1f30e"},
            {":earth_asia:", "_1f30f"},
            {":egg:", "_1f373"},
            {":eggplant:", "_1f346"},
            {":eight:", "_0038-20e3"},
            {":eight_pointed_black_star:", "_2734"},
            {":eight_spoked_asterisk:", "_2733"},
            {":electric_plug:", "_1f50c"},
            {":elephant:", "_1f418"},
            {":email:", "_2709"},
            {":end:", "_1f51a"},
            {":envelope:", "_2709"},
            {":envelope_with_arrow:", "_1f4e9"},
            {":es:", "_1f1ea-1f1f8"},
            {":euro:", "_1f4b6"},
            {":european_castle:", "_1f3f0"},
            {":european_post_office:", "_1f3e4"},
            {":evergreen_tree:", "_1f332"},
            {":exclamation:", "_2757"},
            {":expressionless:", "_1f611"},
            {":eyeglasses:", "_1f453"},
            {":eyes:", "_1f440"},
            {":facepunch:", "_1f44a"},
            {":factory:", "_1f3ed"},
            {":fallen_leaf:", "_1f342"},
            {":family:", "_1f46a"},
            {":fast_forward:", "_23e9"},
            {":fax:", "_1f4e0"},
            {":fearful:", "_1f628"},
            {":feelsgood:", "_feelsgood"},
            {":feet:", "_1f43e"},
            {":ferris_wheel:", "_1f3a1"},
            {":file_folder:", "_1f4c1"},
            {":finnadie:", "_finnadie"},
            {":fire:", "_1f525"},
            {":fire_engine:", "_1f692"},
            {":fireworks:", "_1f386"},
            {":first_quarter_moon:", "_1f313"},
            {":first_quarter_moon_with_face:", "_1f31b"},
            {":fish:", "_1f41f"},
            {":fish_cake:", "_1f365"},
            {":fishing_pole_and_fish:", "_1f3a3"},
            {":fist:", "_270a"},
            {":five:", "_0035-20e3"},
            {":flags:", "_1f38f"},
            {":flashlight:", "_1f526"},
            {":flipper:", "_1f42c"},
            {":floppy_disk:", "_1f4be"},
            {":flower_playing_cards:", "_1f3b4"},
            {":flushed:", "_1f633"},
            {":foggy:", "_1f301"},
            {":football:", "_1f3c8"},
            {":footprints:", "_1f463"},
            {":fork_and_knife:", "_1f374"},
            {":fountain:", "_26f2"},
            {":four:", "_0034-20e3"},
            {":four_leaf_clover:", "_1f340"},
            {":fr:", "_1f1eb-1f1f7"},
            {":free:", "_1f193"},
            {":fried_shrimp:", "_1f364"},
            {":fries:", "_1f35f"},
            {":frog:", "_1f438"},
            {":frowning:", "_1f626"},
            {":fu:", "_fu"},
            {":fuelpump:", "_26fd"},
            {":full_moon:", "_1f315"},
            {":full_moon_with_face:", "_1f31d"},
            {":game_die:", "_1f3b2"},
            {":gb:", "_1f1ec-1f1e7"},
            {":gem:", "_1f48e"},
            {":gemini:", "_264a"},
            {":ghost:", "_1f47b"},
            {":gift:", "_1f381"},
            {":gift_heart:", "_1f49d"},
            {":girl:", "_1f467"},
            {":globe_with_meridians:", "_1f310"},
            {":goat:", "_1f410"},
            {":goberserk:", "_goberserk"},
            {":godmode:", "_godmode"},
            {":golf:", "_26f3"},
            {":grapes:", "_1f347"},
            {":green_apple:", "_1f34f"},
            {":green_book:", "_1f4d7"},
            {":green_heart:", "_1f49a"},
            {":grey_exclamation:", "_2755"},
            {":grey_question:", "_2754"},
            {":grimacing:", "_1f62c"},
            {":grin:", "_1f601"},
            {":grinning:", "_1f600"},
            {":guardsman:", "_1f482"},
            {":guitar:", "_1f3b8"},
            {":gun:", "_1f52b"},
            {":haircut:", "_1f487"},
            {":hamburger:", "_1f354"},
            {":hammer:", "_1f528"},
            {":hamster:", "_1f439"},
            {":hand:", "_270b"},
            {":handbag:", "_1f45c"},
            {":hankey:", "_1f4a9"},
            {":hash:", "_0023-20e3"},
            {":hatched_chick:", "_1f425"},
            {":hatching_chick:", "_1f423"},
            {":headphones:", "_1f3a7"},
            {":hear_no_evil:", "_1f649"},
            {":heart:", "_2764"},
            {":heart_decoration:", "_1f49f"},
            {":heart_eyes:", "_1f60d"},
            {":heart_eyes_cat:", "_1f63b"},
            {":heartbeat:", "_1f493"},
            {":heartpulse:", "_1f497"},
            {":hearts:", "_2665"},
            {":heavy_check_mark:", "_2714"},
            {":heavy_division_sign:", "_2797"},
            {":heavy_dollar_sign:", "_1f4b2"},
            {":heavy_exclamation_mark:", "_2757"},
            {":heavy_minus_sign:", "_2796"},
            {":heavy_multiplication_x:", "_2716"},
            {":heavy_plus_sign:", "_2795"},
            {":helicopter:", "_1f681"},
            {":herb:", "_1f33f"},
            {":hibiscus:", "_1f33a"},
            {":high_brightness:", "_1f506"},
            {":high_heel:", "_1f460"},
            {":hocho:", "_1f52a"},
            {":honey_pot:", "_1f36f"},
            {":honeybee:", "_1f41d"},
            {":horse:", "_1f434"},
            {":horse_racing:", "_1f3c7"},
            {":hospital:", "_1f3e5"},
            {":hotel:", "_1f3e8"},
            {":hotsprings:", "_2668"},
            {":hourglass:", "_231b"},
            {":hourglass_flowing_sand:", "_23f3"},
            {":house:", "_1f3e0"},
            {":house_with_garden:", "_1f3e1"},
            {":hurtrealbad:", "_hurtrealbad"},
            {":hushed:", "_1f62f"},
            {":ice_cream:", "_1f368"},
            {":icecream:", "_1f366"},
            {":id:", "_1f194"},
            {":ideograph_advantage:", "_1f250"},
            {":imp:", "_1f47f"},
            {":inbox_tray:", "_1f4e5"},
            {":incoming_envelope:", "_1f4e8"},
            {":information_desk_person:", "_1f481"},
            {":information_source:", "_2139"},
            {":innocent:", "_1f607"},
            {":interrobang:", "_2049"},
            {":iphone:", "_1f4f1"},
            {":it:", "_1f1ee-1f1f9"},
            {":izakaya_lantern:", "_1f3ee"},
            {":jack_o_lantern:", "_1f383"},
            {":japan:", "_1f5fe"},
            {":japanese_castle:", "_1f3ef"},
            {":japanese_goblin:", "_1f47a"},
            {":japanese_ogre:", "_1f479"},
            {":jeans:", "_1f456"},
            {":joy:", "_1f602"},
            {":joy_cat:", "_1f639"},
            {":jp:", "_1f1ef-1f1f5"},
            {":key:", "_1f511"},
            {":keycap_ten:", "_1f51f"},
            {":kimono:", "_1f458"},
            {":kiss:", "_1f48b"},
            {":kissing:", "_1f617"},
            {":kissing_cat:", "_1f63d"},
            {":kissing_closed_eyes:", "_1f61a"},
            {":kissing_heart:", "_1f618"},
            {":kissing_smiling_eyes:", "_1f619"},
            {":knife:", "_1f52a"},
            {":koala:", "_1f428"},
            {":koko:", "_1f201"},
            {":kr:", "_1f1f0-1f1f7"},
            {":lantern:", "_1f3ee"},
            {":large_blue_circle:", "_1f535"},
            {":large_blue_diamond:", "_1f537"},
            {":large_orange_diamond:", "_1f536"},
            {":last_quarter_moon:", "_1f317"},
            {":last_quarter_moon_with_face:", "_1f31c"},
            {":laughing:", "_1f606"},
            {":leaves:", "_1f343"},
            {":ledger:", "_1f4d2"},
            {":left_luggage:", "_1f6c5"},
            {":left_right_arrow:", "_2194"},
            {":leftwards_arrow_with_hook:", "_21a9"},
            {":lemon:", "_1f34b"},
            {":leo:", "_264c"},
            {":leopard:", "_1f406"},
            {":libra:", "_264e"},
            {":light_rail:", "_1f688"},
            {":link:", "_1f517"},
            {":lips:", "_1f444"},
            {":lipstick:", "_1f484"},
            {":lock:", "_1f512"},
            {":lock_with_ink_pen:", "_1f50f"},
            {":lollipop:", "_1f36d"},
            {":loop:", "_27bf"},
            {":loud_sound:", "_1f50a"},
            {":loudspeaker:", "_1f4e2"},
            {":love_hotel:", "_1f3e9"},
            {":love_letter:", "_1f48c"},
            {":low_brightness:", "_1f505"},
            {":m:", "_24c2"},
            {":mag:", "_1f50d"},
            {":mag_right:", "_1f50e"},
            {":mahjong:", "_1f004"},
            {":mailbox:", "_1f4eb"},
            {":mailbox_closed:", "_1f4ea"},
            {":mailbox_with_mail:", "_1f4ec"},
            {":mailbox_with_no_mail:", "_1f4ed"},
            {":man:", "_1f468"},
            {":man_with_gua_pi_mao:", "_1f472"},
            {":man_with_turban:", "_1f473"},
            {":mans_shoe:", "_1f45e"},
            {":maple_leaf:", "_1f341"},
            {":mask:", "_1f637"},
            {":massage:", "_1f486"},
            {":meat_on_bone:", "_1f356"},
            {":mega:", "_1f4e3"},
            {":melon:", "_1f348"},
            {":memo:", "_1f4dd"},
            {":mens:", "_1f6b9"},
            {":metal:", "_metal"},
            {":metro:", "_1f687"},
            {":microphone:", "_1f3a4"},
            {":microscope:", "_1f52c"},
            {":milky_way:", "_1f30c"},
            {":minibus:", "_1f690"},
            {":minidisc:", "_1f4bd"},
            {":mobile_phone_off:", "_1f4f4"},
            {":money_with_wings:", "_1f4b8"},
            {":moneybag:", "_1f4b0"},
            {":monkey:", "_1f412"},
            {":monkey_face:", "_1f435"},
            {":monorail:", "_1f69d"},
            {":moon:", "_1f314"},
            {":mortar_board:", "_1f393"},
            {":mount_fuji:", "_1f5fb"},
            {":mountain_bicyclist:", "_1f6b5"},
            {":mountain_cableway:", "_1f6a0"},
            {":mountain_railway:", "_1f69e"},
            {":mouse:", "_1f42d"},
            {":mouse2:", "_1f401"},
            {":movie_camera:", "_1f3a5"},
            {":moyai:", "_1f5ff"},
            {":muscle:", "_1f4aa"},
            {":mushroom:", "_1f344"},
            {":musical_keyboard:", "_1f3b9"},
            {":musical_note:", "_1f3b5"},
            {":musical_score:", "_1f3bc"},
            {":mute:", "_1f507"},
            {":nail_care:", "_1f485"},
            {":name_badge:", "_1f4db"},
            {":neckbeard:", "_neckbeard"},
            {":necktie:", "_1f454"},
            {":negative_squared_cross_mark:", "_274e"},
            {":neutral_face:", "_1f610"},
            {":new:", "_1f195"},
            {":new_moon:", "_1f311"},
            {":new_moon_with_face:", "_1f31a"},
            {":newspaper:", "_1f4f0"},
            {":ng:", "_1f196"},
            {":night_with_stars:", "_1f303"},
            {":nine:", "_0039-20e3"},
            {":no_bell:", "_1f515"},
            {":no_bicycles:", "_1f6b3"},
            {":no_entry:", "_26d4"},
            {":no_entry_sign:", "_1f6ab"},
            {":no_good:", "_1f645"},
            {":no_mobile_phones:", "_1f4f5"},
            {":no_mouth:", "_1f636"},
            {":no_pedestrians:", "_1f6b7"},
            {":no_smoking:", "_1f6ad"},
            {":non-potable_water:", "_1f6b1"},
            {":nose:", "_1f443"},
            {":notebook:", "_1f4d3"},
            {":notebook_with_decorative_cover:", "_1f4d4"},
            {":notes:", "_1f3b6"},
            {":nut_and_bolt:", "_1f529"},
            {":o:", "_2b55"},
            {":o2:", "_1f17e"},
            {":ocean:", "_1f30a"},
            {":octocat:", "_octocat"},
            {":octopus:", "_1f419"},
            {":oden:", "_1f362"},
            {":office:", "_1f3e2"},
            {":ok:", "_1f197"},
            {":ok_hand:", "_1f44c"},
            {":ok_woman:", "_1f646"},
            {":older_man:", "_1f474"},
            {":older_woman:", "_1f475"},
            {":on:", "_1f51b"},
            {":oncoming_automobile:", "_1f698"},
            {":oncoming_bus:", "_1f68d"},
            {":oncoming_police_car:", "_1f694"},
            {":oncoming_taxi:", "_1f696"},
            {":one:", "_0031-20e3"},
            {":open_book:", "_1f4d6"},
            {":open_file_folder:", "_1f4c2"},
            {":open_hands:", "_1f450"},
            {":open_mouth:", "_1f62e"},
            {":ophiuchus:", "_26ce"},
            {":orange_book:", "_1f4d9"},
            {":outbox_tray:", "_1f4e4"},
            {":ox:", "_1f402"},
            {":package:", "_1f4e6"},
            {":page_facing_up:", "_1f4c4"},
            {":page_with_curl:", "_1f4c3"},
            {":pager:", "_1f4df"},
            {":palm_tree:", "_1f334"},
            {":panda_face:", "_1f43c"},
            {":paperclip:", "_1f4ce"},
            {":parking:", "_1f17f"},
            {":part_alternation_mark:", "_303d"},
            {":partly_sunny:", "_26c5"},
            {":passport_control:", "_1f6c2"},
            {":paw_prints:", "_1f43e"},
            {":peach:", "_1f351"},
            {":pear:", "_1f350"},
            {":pencil:", "_1f4dd"},
            {":pencil2:", "_270f"},
            {":penguin:", "_1f427"},
            {":pensive:", "_1f614"},
            {":performing_arts:", "_1f3ad"},
            {":persevere:", "_1f623"},
            {":person_frowning:", "_1f64d"},
            {":person_with_blond_hair:", "_1f471"},
            {":person_with_pouting_face:", "_1f64e"},
            {":phone:", "_260e"},
            {":pig:", "_1f437"},
            {":pig2:", "_1f416"},
            {":pig_nose:", "_1f43d"},
            {":pill:", "_1f48a"},
            {":pineapple:", "_1f34d"},
            {":pisces:", "_2653"},
            {":pizza:", "_1f355"},
            {":point_down:", "_1f447"},
            {":point_left:", "_1f448"},
            {":point_right:", "_1f449"},
            {":point_up:", "_261d"},
            {":point_up_2:", "_1f446"},
            {":police_car:", "_1f693"},
            {":poodle:", "_1f429"},
            {":poop:", "_1f4a9"},
            {":post_office:", "_1f3e3"},
            {":postal_horn:", "_1f4ef"},
            {":postbox:", "_1f4ee"},
            {":potable_water:", "_1f6b0"},
            {":pouch:", "_1f45d"},
            {":poultry_leg:", "_1f357"},
            {":pound:", "_1f4b7"},
            {":pouting_cat:", "_1f63e"},
            {":pray:", "_1f64f"},
            {":princess:", "_1f478"},
            {":punch:", "_1f44a"},
            {":purple_heart:", "_1f49c"},
            {":purse:", "_1f45b"},
            {":pushpin:", "_1f4cc"},
            {":put_litter_in_its_place:", "_1f6ae"},
            {":question:", "_2753"},
            {":rabbit:", "_1f430"},
            {":rabbit2:", "_1f407"},
            {":racehorse:", "_1f40e"},
            {":radio:", "_1f4fb"},
            {":radio_button:", "_1f518"},
            {":rage:", "_1f621"},
            {":rage1:", "_rage1"},
            {":rage2:", "_rage2"},
            {":rage3:", "_rage3"},
            {":rage4:", "_rage4"},
            {":railway_car:", "_1f683"},
            {":rainbow:", "_1f308"},
            {":raised_hand:", "_270b"},
            {":raised_hands:", "_1f64c"},
            {":raising_hand:", "_1f64b"},
            {":ram:", "_1f40f"},
            {":ramen:", "_1f35c"},
            {":rat:", "_1f400"},
            {":recycle:", "_267b"},
            {":red_car:", "_1f697"},
            {":red_circle:", "_1f534"},
            {":registered:", "_00ae"},
            {":relaxed:", "_263a"},
            {":relieved:", "_1f60c"},
            {":repeat:", "_1f501"},
            {":repeat_one:", "_1f502"},
            {":restroom:", "_1f6bb"},
            {":revolving_hearts:", "_1f49e"},
            {":rewind:", "_23ea"},
            {":ribbon:", "_1f380"},
            {":rice:", "_1f35a"},
            {":rice_ball:", "_1f359"},
            {":rice_cracker:", "_1f358"},
            {":rice_scene:", "_1f391"},
            {":ring:", "_1f48d"},
            {":rocket:", "_1f680"},
            {":roller_coaster:", "_1f3a2"},
            {":rooster:", "_1f413"},
            {":rose:", "_1f339"},
            {":rotating_light:", "_1f6a8"},
            {":round_pushpin:", "_1f4cd"},
            {":rowboat:", "_1f6a3"},
            {":ru:", "_1f1f7-1f1fa"},
            {":rugby_football:", "_1f3c9"},
            {":runner:", "_1f3c3"},
            {":running:", "_1f3c3"},
            {":running_shirt_with_sash:", "_1f3bd"},
            {":sa:", "_1f202"},
            {":sagittarius:", "_2650"},
            {":sailboat:", "_26f5"},
            {":sake:", "_1f376"},
            {":sandal:", "_1f461"},
            {":santa:", "_1f385"},
            {":satellite:", "_1f4e1"},
            {":satisfied:", "_1f606"},
            {":saxophone:", "_1f3b7"},
            {":school:", "_1f3eb"},
            {":school_satchel:", "_1f392"},
            {":scissors:", "_2702"},
            {":scorpius:", "_264f"},
            {":scream:", "_1f631"},
            {":scream_cat:", "_1f640"},
            {":scroll:", "_1f4dc"},
            {":seat:", "_1f4ba"},
            {":secret:", "_3299"},
            {":see_no_evil:", "_1f648"},
            {":seedling:", "_1f331"},
            {":seven:", "_0037-20e3"},
            {":shaved_ice:", "_1f367"},
            {":sheep:", "_1f411"},
            {":shell:", "_1f41a"},
            {":ship:", "_1f6a2"},
            {":shipit:", "_shipit"},
            {":shirt:", "_1f455"},
            {":shit:", "_1f4a9"},
            {":shoe:", "_1f45e"},
            {":shower:", "_1f6bf"},
            {":signal_strength:", "_1f4f6"},
            {":six:", "_0036-20e3"},
            {":six_pointed_star:", "_1f52f"},
            {":ski:", "_1f3bf"},
            {":skull:", "_1f480"},
            {":sleeping:", "_1f634"},
            {":sleepy:", "_1f62a"},
            {":slot_machine:", "_1f3b0"},
            {":small_blue_diamond:", "_1f539"},
            {":small_orange_diamond:", "_1f538"},
            {":small_red_triangle:", "_1f53a"},
            {":small_red_triangle_down:", "_1f53b"},
            {":smile:", "_1f604"},
            {":smile_cat:", "_1f638"},
            {":smiley:", "_1f603"},
            {":smiley_cat:", "_1f63a"},
            {":smiling_imp:", "_1f608"},
            {":smirk:", "_1f60f"},
            {":smirk_cat:", "_1f63c"},
            {":smoking:", "_1f6ac"},
            {":snail:", "_1f40c"},
            {":snake:", "_1f40d"},
            {":snowboarder:", "_1f3c2"},
            {":snowflake:", "_2744"},
            {":snowman:", "_26c4"},
            {":sob:", "_1f62d"},
            {":soccer:", "_26bd"},
            {":soon:", "_1f51c"},
            {":sos:", "_1f198"},
            {":sound:", "_1f509"},
            {":space_invader:", "_1f47e"},
            {":spades:", "_2660"},
            {":spaghetti:", "_1f35d"},
            {":sparkle:", "_2747"},
            {":sparkler:", "_1f387"},
            {":sparkles:", "_2728"},
            {":sparkling_heart:", "_1f496"},
            {":speak_no_evil:", "_1f64a"},
            {":speaker:", "_1f508"},
            {":speech_balloon:", "_1f4ac"},
            {":speedboat:", "_1f6a4"},
            {":squirrel:", "_shipit"},
            {":star:", "_2b50"},
            {":star2:", "_1f31f"},
            {":stars:", "_1f320"},
            {":station:", "_1f689"},
            {":statue_of_liberty:", "_1f5fd"},
            {":steam_locomotive:", "_1f682"},
            {":stew:", "_1f372"},
            {":straight_ruler:", "_1f4cf"},
            {":strawberry:", "_1f353"},
            {":stuck_out_tongue:", "_1f61b"},
            {":stuck_out_tongue_closed_eyes:", "_1f61d"},
            {":stuck_out_tongue_winking_eye:", "_1f61c"},
            {":sun_with_face:", "_1f31e"},
            {":sunflower:", "_1f33b"},
            {":sunglasses:", "_1f60e"},
            {":sunny:", "_2600"},
            {":sunrise:", "_1f305"},
            {":sunrise_over_mountains:", "_1f304"},
            {":surfer:", "_1f3c4"},
            {":sushi:", "_1f363"},
            {":suspect:", "_suspect"},
            {":suspension_railway:", "_1f69f"},
            {":sweat:", "_1f613"},
            {":sweat_drops:", "_1f4a6"},
            {":sweat_smile:", "_1f605"},
            {":sweet_potato:", "_1f360"},
            {":swimmer:", "_1f3ca"},
            {":symbols:", "_1f523"},
            {":syringe:", "_1f489"},
            {":tada:", "_1f389"},
            {":tanabata_tree:", "_1f38b"},
            {":tangerine:", "_1f34a"},
            {":taurus:", "_2649"},
            {":taxi:", "_1f695"},
            {":tea:", "_1f375"},
            {":telephone:", "_260e"},
            {":telephone_receiver:", "_1f4de"},
            {":telescope:", "_1f52d"},
            {":tennis:", "_1f3be"},
            {":tent:", "_26fa"},
            {":thought_balloon:", "_1f4ad"},
            {":three:", "_0033-20e3"},
            {":thumbsdown:", "_1f44e"},
            {":thumbsup:", "_1f44d"},
            {":ticket:", "_1f3ab"},
            {":tiger:", "_1f42f"},
            {":tiger2:", "_1f405"},
            {":tired_face:", "_1f62b"},
            {":tm:", "_2122"},
            {":toilet:", "_1f6bd"},
            {":tokyo_tower:", "_1f5fc"},
            {":tomato:", "_1f345"},
            {":tongue:", "_1f445"},
            {":top:", "_1f51d"},
            {":tophat:", "_1f3a9"},
            {":tractor:", "_1f69c"},
            {":traffic_light:", "_1f6a5"},
            {":train:", "_1f68b"},
            {":train2:", "_1f686"},
            {":tram:", "_1f68a"},
            {":triangular_flag_on_post:", "_1f6a9"},
            {":triangular_ruler:", "_1f4d0"},
            {":trident:", "_1f531"},
            {":triumph:", "_1f624"},
            {":trolleybus:", "_1f68e"},
            {":trollface:", "_trollface"},
            {":trophy:", "_1f3c6"},
            {":tropical_drink:", "_1f379"},
            {":tropical_fish:", "_1f420"},
            {":truck:", "_1f69a"},
            {":trumpet:", "_1f3ba"},
            {":tshirt:", "_1f455"},
            {":tulip:", "_1f337"},
            {":turtle:", "_1f422"},
            {":tv:", "_1f4fa"},
            {":twisted_rightwards_arrows:", "_1f500"},
            {":two:", "_0032-20e3"},
            {":two_hearts:", "_1f495"},
            {":two_men_holding_hands:", "_1f46c"},
            {":two_women_holding_hands:", "_1f46d"},
            {":u5272:", "_1f239"},
            {":u5408:", "_1f234"},
            {":u55b6:", "_1f23a"},
            {":u6307:", "_1f22f"},
            {":u6708:", "_1f237"},
            {":u6709:", "_1f236"},
            {":u6e80:", "_1f235"},
            {":u7121:", "_1f21a"},
            {":u7533:", "_1f238"},
            {":u7981:", "_1f232"},
            {":u7a7a:", "_1f233"},
            {":uk:", "_1f1ec-1f1e7"},
            {":umbrella:", "_2614"},
            {":unamused:", "_1f612"},
            {":underage:", "_1f51e"},
            {":unlock:", "_1f513"},
            {":up:", "_1f199"},
            {":us:", "_1f1fa-1f1f8"},
            {":v:", "_270c"},
            {":vertical_traffic_light:", "_1f6a6"},
            {":vhs:", "_1f4fc"},
            {":vibration_mode:", "_1f4f3"},
            {":video_camera:", "_1f4f9"},
            {":video_game:", "_1f3ae"},
            {":violin:", "_1f3bb"},
            {":virgo:", "_264d"},
            {":volcano:", "_1f30b"},
            {":vs:", "_1f19a"},
            {":walking:", "_1f6b6"},
            {":waning_crescent_moon:", "_1f318"},
            {":waning_gibbous_moon:", "_1f316"},
            {":warning:", "_26a0"},
            {":watch:", "_231a"},
            {":water_buffalo:", "_1f403"},
            {":watermelon:", "_1f349"},
            {":wave:", "_1f44b"},
            {":wavy_dash:", "_3030"},
            {":waxing_crescent_moon:", "_1f312"},
            {":waxing_gibbous_moon:", "_1f314"},
            {":wc:", "_1f6be"},
            {":weary:", "_1f629"},
            {":wedding:", "_1f492"},
            {":whale:", "_1f433"},
            {":whale2:", "_1f40b"},
            {":wheelchair:", "_267f"},
            {":white_check_mark:", "_2705"},
            {":white_circle:", "_26aa"},
            {":white_flower:", "_1f4ae"},
            {":white_large_square:", "_2b1c"},
            {":white_medium_small_square:", "_25fd"},
            {":white_medium_square:", "_25fb"},
            {":white_small_square:", "_25ab"},
            {":white_square_button:", "_1f533"},
            {":wind_chime:", "_1f390"},
            {":wine_glass:", "_1f377"},
            {":wink:", "_1f609"},
            {":wolf:", "_1f43a"},
            {":woman:", "_1f469"},
            {":womans_clothes:", "_1f45a"},
            {":womans_hat:", "_1f452"},
            {":womens:", "_1f6ba"},
            {":worried:", "_1f61f"},
            {":wrench:", "_1f527"},
            {":x:", "_274c"},
            {":yellow_heart:", "_1f49b"},
            {":yen:", "_1f4b4"},
            {":yum:", "_1f60b"},
            {":zap:", "_26a1"},
            {":zero:", "_0030-20e3"},
            {":zzz:", "_1f4a4"}
        };
    }
}