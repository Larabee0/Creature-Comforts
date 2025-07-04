// Tags Key
// s [name] = speaking [name]
// h [num]  = head [sprite num]
// b [num]  = body [sprite num]
// a [num]  = arms [sprite num]

“Oh thank goodness! I wanted to come and see you as soon as I was able.” # s Mothman # b 3 # a 0 # h 11 # p 0

<i>He appears to be in a hurry but trying to hide it. You haven’t seen him put his jacket on since the night he arrived.</i># s You 

“Is everything alright?”

“No, it is most certainly <i>not</i>.” # s Mothman # h 10

“At first I didn’t understand how they found it… my vacation phone. The one I use to scroll on the internet without the threat of looming work…” # h 2

“Then it dawned on me. Only one person knows about that phone.” # h 11

“<i>Aubrey.</i>” # h 1

“My publishers dutifully notified me that my Press Manager has been located and is back in their offices.” #  h 10

“They strongly suggested I be open to having them join me back on the intended book tour, and that I would get away with a light warning if I agreed to these terms.” # h 1

“I know they are trying to pressure me with veiled threats, they even put Aubrey themselves on the line to make me feel bad.” # h 2

“In all honesty, I’m not sure anything could convince me that the stress of this book release would be any better than the stress I am under already..." # h 11

"Waiting for my Publishers to break down your door at any moment… It's <i>maddening</i>.” # h 10

<i>This is the time to build up some trust, who feels like the more reasonable party here?</i> # s You

*[“You are still under contract you know…”] -> contract
*[“Your Publishers are being unfair!”] -> unfair

=== contract ===

“I don’t know why I expected someone of your caliber to be on the same page as me.” # s Mothman # h 10 # minus 1

“Maybe my hopes were wrongly placed…” # h 11

<i>He seems just as disdainful as he’s always been. Probably for the best that you are trying to remain uninvolved.</i> # s You # h 1

-> speakup

=== unfair ===

“Aren’t they just! I’m glad we see eye to eye, like kindred spirits.” # s Mothman # h 6 # plus 1

<i>He seems very pleased with your agreement. You really do think his Publishers seem very controlling over him.</i> # s You # 

“You should be able to make your own creative decisions.”  # h 3

<i>He smiles warmly, and for a brief second you realise that he could actually be very gentlemanly, if he put the effort in.</i>

-> speakup

=== speakup ===

“Well… regardless of the outcome of my little rebellion, I really do have to tell someone else, lest I never be allowed to speak of it after today…” # s Mothman # h 11

<i>You remain silent, giving him the time to formulate his thoughts.</i> # s You

“I want to pitch you my new manuscript idea, the one I have been working on the past couple nights.” # s Mothman # h 2

<i>Finally, he’s about to spill all of his mysterious secrets!!</i> # s You

<i>This is the most excited you’ve been since they first installed the coffee machine in the hallway.</i> 

“Of course, pitch away!”

“Alright, as you know, my genre is usually historical fiction. These days I’ve felt drawn to something more intense… emotional, <i>dramatic.</i>” # s Mothman # h 3

“I’ve called it <i>‘Jewel of the Night’</i>. A tale of a lonely woman swept away by a mysterious handsome stranger with glowing red eyes… who she later finds out is a scary night creature, with wings!!” # h 9

“Naturally the night creature finds her quite intriguing, as you don’t see many romances between non-creatures and creatures on the market."

"I think I’ve hit a new niche!” # h 6

<i>You attempt to hide your reaction, practicing the utmost poise and restraint.</i> # s You 

<i>Hasn’t this moth ever heard of that one book with the human woman and the mysterious blonde night creature who fall in love despite the protests of everyone around them??</i> # h 3

<i>The one where he sparkles. You are sure everyone knows about that one.</i>

<i>Anyways, you aren’t here to rock their world. Plus, it feels weirdly predictable he’s arrived at this genre. Tales of historical battles really didn’t feel like his style.</i>

<i>Now’s your moment, the big choice… what do you want to do?</i>

*[<i>Support his new creative endeavours.</i>] -> support
*[<i>Let him down gently.</i>] -> deny

=== support ===

“I think you might have a bestseller on your hands!” # s You # plus 1

<i>The chances are closer to 50/50, but you really do want to see him succeed with his creative passion.</i> 

"You honestly think so?”  # s Mothman # h 8

“I always <i>knew</i> you had taste!” # h 6

<i>Funny how he suddenly warms up when you agree with him. Amusingly predictable.</i> # s You

“Great, this is just splendid!” # s Mothman # h 3

<i>His excitement becomes so palpable it's almost as if he’s fluttering around the room.</i> # s You

“Alright, this could work out. Yes, I can see this being quite alright.” # s Mothman # h 6

<i>His muttering has started up again, you let him deliberate on whatever ideas are spinning about in his head.</i> # s You

“If I gather some press attention on my own… Yes, that settles it.” # s Mothman # h 9

<i>He stares at you with the calmest expression you’ve seen from him in days.</i> # s You # h 3

“Congratulations! I formally appoint you as my new (semi) official Press Manager!” # s Mothman # h 6

<i>His…what??? This is not a job you agreed to not be payed for.</i> # s You

“This new book <i>will</i> be going to market, and I trust you will help me in this endeavour.” # s Mothman # h 9

“Your unwavering support has ruffled my feathers, and I look forward to this partnership.” # h 3

<i>Everything is happening so fast you can hardly register the fact you somehow managed to succeed in your quest to beguile this moth.</i> # s You

“Uhh, me too?”

“Marvelous! I’ll be back tomorrow, I have to sort out some induction paperwork for you tonight.” # s Mothman # h 6

“Adieu, dear Manager.” # h 8

<i>Now you’re the one holding back the blush.</i> # s You # a 0 # h 0 # b 0

<i>You have no idea what you just agreed to do, but if it’s an excuse to get closer to Mothman, you’re sure you will figure out a way to complete whatever he throws your way.</i>

-> END

=== deny ===

<i>You have to be honest with him. It would be too painful otherwise...</i> # s You # minus 1

“I’m not sure that’s the most original idea…” # h 4

<i>It is immediately obvious how unprepared he was for any sort of criticism.</i>

“Oh, uh, alright. That’s..fine. Not everyone needs to understand.” # s Mothman # h 11

“It’s ok, I can still find the target demographic…” # h 12

<i>You feel terrible for crashing him down to reality, but better you than his horrible Publishers.</i> # s You

<i>You try and convince yourself it's better for him in the long run.</i>

“After everything, if that’s all you have to say to me, I suppose I will retire to my room.” # s Mothman # h 10

<i>He leaves without so much as a goodbye. Maybe this was the wrong decision? Or perhaps you just happened to provide the voice of reason.</i> # s You # h 0 # b 0 # a 0 
-> END