// Tags Key
// s [name] = speaking [name]
// h [num]  = head [sprite num]
// b [num]  = body [sprite num]
// a [num]  = arms [sprite num]
// p [num]  = hair [sprite num]

<i>You can hear Nessie before she comes into view of the desk, her lab coat swishing against the carpet.</i> # s You

“Finally, I have my plan!!” # s Nessie

<i>At last, maybe she can stop asking you for things you are unable to give her.</i> # s You

“I am going to ask around to see if I can get any help, and then go swim in the lake anyways.” # s Nessie
 
“Things are a little desperate, so no harm in just trying, right?”
 
<i>You are a little shocked at this brazen proposal. Didn’t she just mention not being able to swim very deep??<i/> # s You
 
<i>Regardless, you don’t want to deal with the legal fallout of a guest harming themselves on Motel property.</i>
 
<i>How are you going to stop her from doing this?</i>
 
 *[“There’s a monster in the lake.”] -> monster
 *[“It’s too dangerous!”] ->lakedanger
 
 === monster ===
 
 <i>You realise far too late this was possibly the most insensitive thing you could have said. Massive failure. Catastrophic failure.</i> # s You # minus 1 

Really?????? You think I haven’t heard that one before?” # s Nessie

“I thought you wanted to help me out, not insult me!” 

<i>You try to explain that you didn’t think the comment through, but the effort to convince her outweighs the result. The insult has already sunk in.</i> # s You

 -> fuss
 
 === lakedanger ===
 
“Since when have calm, scenic lakes been a source of danger?" # s Nessie # plus 1
 
"Besides, I swam through there on my way in!” 
 
<i>Man, your logic wasn’t very sound for this argument.</i> # s You
 
“It’s nice of you to worry, but I can handle myself. It’ll just be a little tricky is all.” # s Nessie

 -> fuss
 
 === fuss ===
 
“I don’t know what all your fuss is about, considering I am literally part aquatic.” # s Nessie
 
 <i>You realise your momentary panic about Motel health insurance and injury claims somewhat caused you to forget that your guest is a little more equipped for this scenario than another creature would be.</i> # s You

“Go on, ask your questions, I can tell you are curious. Believe me, I get it all the time…” # s Nessie

*[<i>Ask an uneducated question.</i>] -> scales
*[<i>Back down.</i>] -> bepolite

=== scales ===

<i>You try your very best to think of something smart to ask her, something impressive.</i> # s You # minus 1

“So… you have any scales?”

“Huh?” # s Nessie

<i>She looks stunned, but hopefully not offended…</i> # s You

“I know I said I was reptilian but not like <i>that</i>, silly!!” # s Nessie

“Honestly I don’t know why they don’t educate people on these things in school…”

<i>Nessie seems bemused, but doesn’t explain further. I guess some things you will never get answers to.</i> # s You

-> toofamiliar

=== bepolite ===

<i>You feel too shy, simply opting to shrug and mumble a vague statement instead.</i> # s You # plus 1

“I know it’s a bit scary to ask, don’t worry!" # s Nessie

"I can totally tell you I am able to slightly breathe underwater, for a short time.”

“Also I get dehydrated very quickly and can’t deal with cold temperatures! I could go on, but I don’t want to scare you off with too many facts.”

<i>You’re grateful for the quick save. Plus, a few queries were answered for you.</i> # s You

-> toofamiliar

=== toofamiliar ===

“At least we got that awkwardness out of the way! Now we can move on to the honeymoon stage.” # s Nessie

<i>The what now!?-</i> # s You

<i>If this is her idea of getting to know someone, you suppose being overly confident is one way to go about it… You laugh awkwardly.</i>

“Just kidding! I do feel like I’ve gotten to know you a bit now though.” # s Nessie

“My problem is far from solved, so I’m sure we’ll meet again very soon!!”

“I’m gonna go ask around for flippers……”

<i>You really do hope she manages to heave better luck with the guests than you.</i> # s You # b 0 # h 0 # a 0 # p 0

<i>Looking back at your computer fills you with a sense of guilt. Maybe you can sort something out. Maybe…</i>
 -> END