// Tags Key
// s [name] = speaking [name]
// h [num]  = head [sprite num]
// b [num]  = body [sprite num]
// a [num]  = arms [sprite num]
// p [num]  = hair [sprite num]

<i>This customer was ringing the bell so aggressively you are almost tempted to ignore it. But, duty calls. Reception chores aren’t going anywhere any time soon.</i> # s You # b 1 # a 3 # h 1 # p 1

“Gooood morning!!!!” # s Nessie

<i>The amount of energy put into the simple greeting is far too much to handle this early in the day. You offer a lazy half attempt at a wave back.</i> # s You

“I don’t know if you remember, but I checked in late last night, and I was just wandering about to get a lay of the land…scope out the turf you could say.” # s Nessie # a 1  # h 1

<i>For someone claiming to be “wandering” she seems oddly tight strung.</i> # s You

“I thought I’d come and chat with some of the lovely staff of your, uh, <i>nice</i> establishment.” # s Nessie # h 1 # a 2

 “Isn’t the purple carpet just… so… colorful!” # p 3

<i>Her attempts at flattery mean nothing to you. Besides, you kind of hate the ugly purple carpet.</i> # s You

<i>You’re not really supposed to express ill will towards the decor as your Boss picked it out.</i> # s You # p 1

<i>She is clearly hanging about waiting for something… do you want to engage?</i>

*[<i>Be a good receptionist.</i>] -> goodjob
*[<i>It is too early in the morning for this.</i>] -> tired

=== goodjob ===

“So… do you need anything?” # s You

<i>She stares at you blankly for a minute before ceasing her zoning out.</i> # a 1 # h 1

“Huh? Oh, me? Nah! Thanks for asking though. Very kind of you!!!” # s Nessie # h 2

<i>You are left more confused than before… who comes to the main desk of a hospitality establishment to do anything besides asking for help?</i> # s You
-> spacedout

=== tired ===
<i>You remain awkwardly silent. She also remains awkwardly silent. You suddenly have no idea what you were trying to achieve here.</i> # s You # a 2

<i>You probably should be doing your actual job by greeting the guests correctly. Oh well.</i>
-> spacedout

=== spacedout ===

“Sorry, was I spacing out again? I completely forgot why I came here…” # s Nessie # h 3 # a 1

“Oh! Right! To chat!” # h 5 

“Hi, how are you? I’m Nessie, Nessie L, the L stands for Loch-"

"Now I <i>know</i> that sounds sooo silly but I wasn’t in charge of picking my name…” # h 1 # p 3

<i>Nessie goes on like this for several minutes.</i> # s You

“... You see, I’ve come down here to this part of the woods to research some extra special flora and fauna, but it was such a hassle to make it here, I’m simply EXHAUSTED.” # s Nessie # p 1 

<i>You feel like now is as good a time as any to interject her train of thought with your meager attempts at small talk.<i/>

“Cool. So, what kind of science are you into?” # s You # h 6

“Oooh nobody ever asks me that! I’m a <i>very</i> qualified plant expert!!"

"I mainly look into weird bits of wood that get stuck in lakes and river systems and the like. I am technically not a full scientist yet, but I’m working on it!!” # s Nessie # a 2 # h 2

<i>You wonder where on earth is taking research interns that want to look at damp tree trunks.</i> # s You

<i>Are you really interested in learning about plant science?</i> 

*[“All of this is going over my head.”] -> dumb
*[“That’s fascinating!”] -> smart

=== dumb ===

<i>You thankfully admit that you are not a qualified scientist and therefore have nothing more to add to this conversation.</i> # s You

“Awww mannn you’re no fun! I finally thought someone was actually taking an interest in my career."
"I’ve heard there’s a famous author staying here too, there’s no way I can compete with that!!!” # s Nessie # h 5 # a 1 # p 2

 <i>You smile remembering the state of said famous author this morning. I think the bar is pretty low- on the floor, even.</i> # s You
->graphs

=== smart ===

<i>You hurriedly spout out some words about seaweeds and the local lake foliage. It seems to work pretty well.</i> # s You

“Yay, a fellow plant enthusiast?? SO COOL." # s Nessie # a 3 # h 1 # p 3

"Oops, that was a bit loud." # a 2 # h 3 # p 1

“Sooo coool….” # p 2 h 2

<i>She whispers it this time as if to prove some sort of point. You have to hand it to your new guest, she is actually kind of amusing.</i> # s Nessie

“Since you are a proven plant enthusiast, I can actually tell you the title of my research!"

"It is looking into the effects of hydration on dead tree matter, particularly bark." 
!So basically, when wood is left in water for too long- how does that affect its molecular structure?” # s Nessie # a 1 # h 1 # p 1

“Proper sciencey stuff. If my supervisors like it, then I will be all set for becoming a proper researcher!"
"I work for the Scientific Institution for Aquatic Creatures, a <i>very</i> well known establishment.”

<i>She seems very proud of her position. It's probably a big deal, even though you have never heard of it.</i> # s You # h 2 # a 2
-> graphs

=== graphs ===

“I just know you’ll LOVE what I’m doing if I can show you some of my graphs!" # s Nessie # a 3 # p 1 # h 1

“Uhhhh, lets see… where did I put them again????” # h 6 # a 2

“Sorry, just a minute, I won’t be long!” # h 1 # a 1 # p 3

<i>She dips onto the floor in a hurry, before resurfacing just as quickly.</i> # s You # b 0 # a 0  # p 0  # h 0

“I seem to have run into a minor problem… only a small one…” # s Nessie # b 1 # a 2 # h 3 # p 1

 “I can’t find my computer anywhere… or my phone, come to think of it.” # p 2 ' h 5

“I’m- I’m sure I just left it in my room!! I promise I’ll be back to show you all my cool stuff.” # h 4 # p 2 # a 1

<i>She speeds off into the distance at an alarming rate, rummaging frantically through the pockets of her lab coat. </i> # s You # b 0 # a 0  # p 0  # h 0

<i>Looks like you dodged a bullet. No plant graphs? What a catastrophe.</i>
-> END