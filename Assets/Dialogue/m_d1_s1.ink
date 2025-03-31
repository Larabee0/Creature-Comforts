// Tags Key
// s [name] = speaking [name]
// h [num]  = head [sprite num]
// b [num]  = body [sprite num]
// a [num]  = arms [sprite num]
// e        = end tag

“Good Morning, am I the first one here?” # s Mothman #h 2 # b 2 # a 2

<i>You reflect on the time, amused that he seems to think anyone else would even be up at this early of an hour.</i> # s You

<i>He is the first person you’ve seen…but will you choose to tell him as such?</i> # b 1 # a 3

*[“I’ve seen plenty of other guests come through today.” ] -> seen1
*[ “What’s it to you? I thought moths were nocturnal…”] -> seen2
*[“Yes, you are.”] -> seen3 

=== seen1 ===

<i>This is a blatant lie, but you have to find some way to keep yourself entertained in this dreary establishment.</i> # s You # minus 1

“That’s just <i>great</i>. I may already have a huge problem on my hands...” # s Mothman # h 5

“Honestly, why does trouble <i>always</i> seem to follow my vacation leave!” # h 10


<i>You notice his irritability. Seeing guests unhappy even after check-in always gets you down. You can’t help but feel a little guilty.</i> # s You

-> lastnight

=== seen2 ===

“Excuse me? You’re far too nosy for a receptionist.” # s Mothman # h 10 # plus 0
“I’m sure there are better things to do than pry into guests' personal matters.” # h 1 # b 1 # a 1

<i>You wish he was correct, but he couldn’t be more wrong.</i> # s You
<i>Small talk is the most riveting thing around here, even on good days.</i>

“In regards to your question, I get up when I please." # s Mothman # h 6
"Happy now?” # h 1

<i>You crack a small smile, which he doesn’t seem to find amusing.</i> # s You # h 2
<i>A moth that doesn’t sleep during the day? How times are changing.</i>

-> lastnight

=== seen3 ===

“Splendid. There may still be time yet to fix this. Perhaps they merely haven’t arrived yet.” # s Mothman # h 3 # plus 1
“My punctuality has always been a burden when it comes to situations like this.” # h 1

<i>The obvious bragging does not escape your attention. You wonder who they might be expecting.</i> # s You # h 3

-> lastnight

=== lastnight ===

“Enough with the idle small talk, let's address the matter at hand.” # s Mothman # h 1 # b 2 # a 2
“Although, it’s not like you seemed to be doing much before I arrived.” # h 3

<i>The pile of guests’ paperwork you still have left to complete agrees with him.</i> # s You # h 2
<i>You feel like he seems hesitant to ask you whatever is on his mind. He keeps glancing in the direction of your telephone with a worried expression. </i> # s You # h 5

“I know I have already pried, but are you sure you haven’t seen anyone with the following description since last night?” # s Mothman # b 1 # a 1 # h 11 
“They would be wearing a tie with a little red pocket square, and be carrying with them a rather large briefcase…” # h 2
“… a briefcase full of newly printed, half signed, Advanced Readers Copies of my newest book…” # h 5
“Let me assure you this is a purely professional, <i>not</i> personal matter." # h 2
"I have simply lost my Press Manager on the way here…somehow.” # h 1
“I’m sure my publishers will compensate you for your troubles if you choose to help.” # h 3

<i>You try to recall the events of last night. He seems like an important figure, famous, even.</i> # s You
<i>Is it wise to be getting involved in whatever this mix up seems to be?</i> 

*[“I'm afraid I can’t tell you that. Receptionist's honor!” ] -> lastnight1
*[“Nobody else matching that description stopped by.”] -> lastnight2

=== lastnight1 ===

“Seriously? Is this what you call customer service in this part of the woods?” # s Mothman # h 11 # b 2 # a 2 # minus 1
“I could really use even a <i>tiny</i> ounce of co-operation right now.” # h 7
  
<i>Oops. You seem to have annoyed him with your nonchalant act.</i> # s You # h 11
<i>That self improvement book lied to you. So much for suggesting that being aloof makes you seem more interesting to strangers.</i>  # h 1

<i>You cave and tell him what he wants to know.</i>  # h 2

“Just kidding… I haven’t seen who you are looking for.”

 -> managerlocation

=== lastnight2 ===

“Sorry to break it to you, <i>you</i> were the last guest to check in last night.” # s You # h 5 # plus 1
 
 <i>Well.. apart from that frazzled reptile woman. She doesn’t seem to fit the description though.</i>

-> managerlocation

=== managerlocation ===

“Ohhh dear, the books… Moth save me.” # s Mothman # h 12 # b 1 # a 3
“I <i>must</i> have lost them on the way here.” # h 10
“Yes… that’s the only logical explanation. Aubrey wouldn’t just abandon me like this.” # h 5
“They are… <i>far</i> too clingy.” # h 1

<i>They look around the lobby with an increasingly concerned expression.</i> # s You # h 10

<i>You feel like now is a good time to ask for some more context.</i> # h 5

 “So Aubrey is the person you are looking for? And they are… your manager?”
 
 "Yes. My <i>Press</i> Manager to be exact. They were supposed to accompany me on my latest pre-release tour, but I wanted to take a little detour first…" # s Mothman # b 2 # a 2 # h 2
"All below board, you see. Which is why it's rather inconvenient they have gotten lost with a briefcase full of unreleased books all conveniently sporting my name in large letters." # h 1
“I knew I shouldn’t have flown in. They can never keep up with me during arial travel…” # h 11

<i>His answers have raised a million more questions for you. You suddenly recall his check-in slip mentioning he was an Author.</i># s You # b 1 # a 3
<i>Now doesn’t seem the time for more prying, as he seems incredibly on edge.</i>

*[ “Is there anything else I can do?”] ->managerloc1
*[ <i>You’ve met his type before. Best to leave him to his muttering. </i>] -> managerloc2

=== managerloc1 ===

“Moths <i>no</i>, you’ve proved yourself rather useless already.” # s Mothman # h 10 # b 2 # a 2 # minus 1
“It’s not as if you can make a person suddenly appear, and that is the only thing that will currently solve my problem.” # h 11
“Ugh, I need a cup of coffee. Where is the machine?” # h 10

<i>You decide to sheepishly point him in the direction of the single lonely Motel coffee station.</i> # s You 

“Down the hall and to the right.” # b 0 # h 0 # a 0

<i>… but by the time the words have left your mouth, he’s already stomped halfway down the corridor…</i>

-> sc1end

=== managerloc2 ===

“I cannot <i>believe</i> I’ve lost my damn Press Manager… My publishers won’t like a word of this and I’m already on thin ice for straying from schedule.” # s Mothman # h 10 # b 2 # a 2 # plus 1
“They might be even more mad about the books though… I am too, but less so.” # h 5

“I can manage without that tasteless garbage being distributed under my name.” # h 1

“Honestly, who thought the 'Roman Empire' was going to be more interesting than the Renaissance, or even the 1800s…” # h 7

<i>He doesn’t appear to be paying attention to you any more, but realises this far too late.</i> # s You # b 1 # a 3 # h 10

“Pardon me, was I rambling off to myself again? I need to go back to my room and make some calls.” # s Mothman # h 2

-> sc1end

=== sc1end ===

<i>Well…that was pretty peculiar. Sounds like a serious problem! Maybe he will return later? # s You # h 0 # b 0 # a 0
-> END
