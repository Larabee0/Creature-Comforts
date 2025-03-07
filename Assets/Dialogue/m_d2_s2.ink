// Tags Key
// s [name] = speaking [name]
// h [num]  = head [sprite num]
// b [num]  = body [sprite num]
// a [num]  = arms [sprite num]

<i>At last, Mothman has shown himself. You note it is much later in the day than you would have expected for him.</i> # s You # b 2 # a 2 # h 2

“Well then?? Did anyone call?” # s Mothman # b 1 # a 3 # h 11

<i>He seems extremely impatient, fidgeting with his shirtsleeves.</i> # s You

“I am assuming the worst, since I didn’t receive any calls in my room.” # s Mothman # h 1

<i>Here’s your big moment, do you tell him the truth?</i> #s You

*[<i>Lie about the phone lines being broken.</i>] -> lie
*[<i>Tell him about your snooping.</i>] -> truth

=== lie ===

“Is there <i>anything</i> that works in this Moth forsaken Motel?” # s Mothman # h 10

<i>You smile sheepishly, hoping he doesn’t notice your anxiety. You always were a terrible liar.</i> # s You

<i>His gaze slips to the notes on your desk, then back up at you.</i> # b 2 # a 2 # h 1

“Hold on a minute, I see my name written down right there!” # s Mothman # h 7

“Why lie to me?? Are you not a receptionist, is your job not to <i>assist</i>??!”

“Sorry, I panicked, and by the time I answered the phone it was too late…” # s You # h 10

<i>He grabs the notes from you and quickly reads them over, face souring.</i> # b 1 # a 1 # h 4

“This is not ideal, but I will have to make do.” # s Mothman # h 2

-> thesituation

=== truth ===

<i>You choose to admit you handled the call yourself, since you were so curious.</i> # s You

“You…” # s Mothman # h 4

“You <i>WHAT</i>?” # b 2 # a 2 # h 7

“Didn’t anyone teach you any <i>manners</i>?!” # h 10

“It is completely and utterly disgraceful to receive a private call intended for another person, <i>especially</i> when it concerns business.” # b 1 # a 1 # h 11

<i>He seems to pause for a moment, cooling off from momentary anger. You already knew what you did was wrong.</i> # s You # b 2  # a 2 # h 2

“Still… I am somewhat grateful I didn’t have to deal with my publishers alone.” # s Mothman # h 1

<i>You notice he visibly relaxes at this realization, a smile creeping onto his face.</i> # s You # h 3

“Your gesture is… strangely valiant. To come to the aid of someone in peril, even when faced with the unknown…” # s Mothman # b 1 # a3 # h 9

“How bizarrely romantic.” # h 8

<i>The blush vanishes as quickly as it appeared.</i> # s You # h 2

-> thesituation

=== thesituation ===

“I suppose it's only fair to tell you how I got myself into this situation in the first place.” # s Mothman # b 2 # a 2 # h 2
 
“Woe is me, the life of an Author can be full of trials and tribulations.” # h 12

“One of which is the release of my latest novel… <i>‘Conquer the Conquered’</i>... and whatever they decided to put as the sub-heading.” # b 1 # a 1 # h 1

“I have been in the historical fiction niche for quite some time, and even I have to admit this was a low blow, even by my standards.”

“I’ve released sequels, threequels, a pentalogy… but nothing comes close to this!” # h 10
 
“I fear I have already hit my creative peak and it’s only downhill from here.” # a 3 # h 11

<i>You choose to stay silent about the fact he’s no doubt profited enough from these books already to inevitably retire comfortably.</i> # s You

<i>Respecting the artist for their art becomes rather difficult when they are a lavishly dressed gentleman and you are a mundane Motel Receptionist.</i>

“Nevertheless, the publishers want what they want, and what they wanted was a ‘tasteful shift in time period to keep things new and fresh with the audience’.” # s Mothman # h 2

“Why do you hate this book so much?” # s You

<i>He pauses, face immediately souring.</i> # h 5

“Don’t get me started. I can recite the blurb to you, seeing as I was forced to memorise it.” # s Mothman # a 3 # h 1

<i>“A tale of two opposing forces on the brink of destruction, set against the backdrop of the Roman Empire. A story filled with action packed violence, desperation and brutal drama. Who will be left conquered, and who will be the conqueror?”</i> # h 9

“Such boring drivel, I didn’t even get a say in what was written for that. I believe it was Aubrey, probably.” # b 2 # a 2 # h 1

<i>Well that certainly was a description for a book. What do you think? Did it inspire you with the passion of the Roman Empire?</i> # s You

*[“Ok, I see your point…”] -> romannah
*[“I don’t know, I think I would buy it!”] -> romanyes

=== romannah ===

<i>You express your absolute and utter abhorrence for the phrases that just left his mouth. That is not literature, you exclaim in feverish tones, that is tasteless rubbish!!</i> # s You # h 3

“At last, an opinion of merit, spoken with such class!” # s Mothman # b 1 # a 1 # h 6

<i>He is beaming proudly, clearly feeling satisfied you agree with him so wholeheartedly. The book didn’t sound great, but you also don’t share his interest and knowledge in history.</i> # s You

<i>Truthfully, you just wanted to say something that would cheer him up.</i>

-> proposition

=== romanyes ===

<i>He stares at you, aghast. Obviously not the words he wanted to hear, but sometimes you have to strike a little bit of reality into the heart of someone absorbed so constantly by their ego.</i> # s You # h 4

“You sound just like Aubrey.” # s Mothman # h 1

“Did my publishers pay you off already or something? Anyone with sense can tell how bad that was...” # b 1 # a 3 # h 11

-> proposition

=== proposition ===

“Regardless of your personal opinions, I prefer things with subtle emotion, tension, and true romance.” # s Mothman # b 1 # a 1 # h 3

“I suppose it isn’t a secret anymore so I will tell you directly. I am currently working on something much more to my tastes.” # h 6

<i>His pride at this admission is evident. You are very intrigued about what sort of book this could be.</i> # s You

“I’m sure you are <i>dying</i> to know… but I want to keep it secret for now. The public aren’t ready… but soon they may be.” # s Mothman# b 2 # a 2 # h 9

<i>A plan begins to formulate in your head- maybe you could encourage him to talk about his new release, proving to those nasty publishers that he still has tricks up his sleeve!</i> # s You

“I’m happy to help with whatever you need.”

<i>Mothman seems taken aback at this declaration. Maybe this was too much fraternization for him to handle…</i> # b 1 # a 3 # h 5

“Is this in regards to my manuscript? I don’t think I’m quite ready yet.” # s Mothman # h 11

“It will take some time to prepare to unleash this side of myself.” # h 11

“Besides, I don’t quite know you. Notwithstanding the fact my personal matters have been exposed to you unwillingly these past few days.” # a 1 # h 2

<i>He seems to stiffen up more as he speaks, fighting against some internal conflict.</i> # s You

“Terribly sorry, but perhaps this discussion is best left for another time.” # s Mothman # h 1

“I hope you have a pleasant afternoon.” # h 3

<i>You wonder what side of him he is so hesitant to ‘unleash’. No doubt something equally as dreary as his interest in history.</i> # s You # b 0 # h 0 # a 0

<i>Still, maybe there’s more to this than meets the eye?</i>

<i>It’s best to forget about your foolish offer to help. He probably has it under control. Definitely.</i>
-> END