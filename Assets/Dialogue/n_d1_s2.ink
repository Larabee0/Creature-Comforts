// Tags Key
// s [name] = speaking [name]
// h [num]  = head [sprite num]
// b [num]  = body [sprite num]
// a [num]  = arms [sprite num]
// p [num]  = hair [sprite num]


“MAJOR CATASTROPHE!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!” # s Nessie # b 1 # h 5 # a 3 # p 3

<i>Nessie waves her arms in front of you haphazardly, distracting you from the paperwork you had definitely not been putting off.</i> # s You

“Is everything alright?” # a 2 # p 1

<i>You immediately realise how stupid that sounds given the context.</i>

 <i>Nessies face falls, clearly not taking the joke well.</i># h 4 # p 2

“No, it is NOT alright! You know how I went to look for my computer so I could show you my very declassified totally awesome plant facts????" # s Nessie # p 3 # h 5 # a 1

"Well, my stuff is MISSING!!!” 

“Before you ask, yes I have checked everywhere already."

"I took in all my bags myself when I arrived and I could have sworn I had everything. Look, I even brought my bag-” # h 4 # p 2

<i>She stops mid sentence, half way through pulling up some sort of luminous green rucksack onto your desk.</i> # s You

<i>It is dripping with water and you really hope she just keeps it where it is.</i> # s You

<i>Water damage on the desk would equal instant reprimands from your Boss.</i> 

“I’m going to have to ask you not to put that on my desk.” # a 1

<i>Your request goes unheard as she’s still frozen, like someone hit the pause switch.</i>

<i>Your mind drifts to images of lizards sleeping on hot rocks under the sun.</i>

“Why… is there a hole in the bottom of my bag.” # s Nessie # p 1 # h 3

"Don’t tell me… no no no…” # h # p 2

“How am I supposed to research waterlogged logs if my research logs are all waterlogged?!!!” # p 3 # h 5

<i>Uh oh. You suddenly remember her mentioning going through the lake to get here. The pieces are coming together.</i> # s You

“<i>Please</i> tell me you have some sort of diving equipment." #s Nessie

"I can’t swim below certain depths and I’ll be in major trouble if what I think has happened… has happened…” # s Nessie # h 6 # p 1 # a 2

*[<i>Awkwardly shake your head.</i>] -> nodive
*[<i>Try and dodge the question.</i>] -> playsilly
*[“Why would a Motel carry diving equipment??”] -> whymotel

=== nodive ===

<i>There is literally no way to lie your way out of this one. Better to be honest with her.</i> # s You

“Sorry, we don’t carry anything like that.” # a 1 

“Oh Nettles. It was worth a shot.” # s Nessie # h 5 # p 2

<i>She smiles sadly at you, as if expecting something more hopeful. You feel awful.</i> # s You # h 4 # a 2

“Do you want a hug or something?”

“Aww, you’re so sweet! I’m a little too anxious at the moment and I don’t know you so well, but thanks anyway." # s Nessie # h 2 # a 1 # p 1

"The offer itself makes me feel more cheerful already!”
-> notlake

=== playsilly ===

“Hmm last time I checked, we don’t carry anything like that. Foggy Lake has lots of other amenities though!” # s You

<i>You do your best to put on a customer service smile, listing out all the things you can possibly think of that the Motel has.</i> # h 6

“We have dry cleaning services, complimentary lobby refreshments… room service…”

“Sorry to interrupt, but <i>none</i> of this is what I’m looking for.” # s Nessie # h 6 # a 1

<i>This must be the one and only time that technically fulfilling your job description has been utterly useless.</i> # s You
-> notlake

=== whymotel ===

“Well I don’t know?!” # s Nessie # h 5 # p 3 # a 1

“You’re literally sitting next to a giant lake, and the name of your Motel reaffirms this!!”

“I don’t think my suggestion is <i>that</i> crazy.” # p 1 # h 6 

<i>Honestly when she puts it like that, you can see her point.</i> # s You

-> notlake

=== notlake ===

“Look, this situation isn’t ideal for me. As far as I can tell, all of my equipment is currently sitting at the bottom of your scenic lake.” # s Nessie # h 3 

“I’m currently working on this project to advance my rank as a junior researcher so it’s really important to me that I can fix this.” # h 1 # p 2 # a 2

<i>You notice she is spiraling further down into a panic. What do you think she needs right now?</i> # s You # h 4

*[<i>Express your condolences.</i>] -> sorrywet
*[“Why did you swim here?”] -> whyswim

=== sorrywet ===

<i>You try your best to be helpfully unhelpful, reassuring Nessie that there should be some way to recover or replace her lost stuff.</i> # s You # a 2 # h 4 # p 2

“My future is on the line here so of course I am going to come up with a plan… eventually.” # s Nessie # h 6 # p 1

“Thanks for your concern and understanding, receptionist!!” # h 2 # a 1

<i>Her seemingly steadfast faith in your usefulness is flattering.</i> # s You

-> returnagain

=== whyswim ===

<i>Nessie looks extremely unamused.</i> # s You # p 1 # h 5 # a 1

“I don’t know, maybe because I am an amphibian who can’t travel long distances out in the open???” # s Nessie # a 2 # p 3

“Aw, I can’t <i>really</i> stay mad at you for not understanding.” # p 2 # h 4 # a 1

“This is why I’m the scientist, and you are <i>not</i>.” # a 3 # h 1 # p 1

<i>She smiles, quickly forgetting your momentary insult. Thank goodness.</i> # s You
-> returnagain

=== returnagain ===

“I won’t bother you all day about my issues, so I will come back once I actually have something you can help me with for real this time!” # s Nessie # h 1 # a 2 # p 1

<i>She cocks her head, looking behind you at something.</i> # s You # h 6 # p 3

“Ooh, you have a computer back there?? Cool!” # s Nessie # p 1 # h 1 # a 1

“Guess I’ll see you around then. Byee!!” # a 3

<i>She runs off for the second time today. You really can’t keep up with her energy.</i> # s You # b 0 # a 0  # p 0  # h 0

<i>Hopefully that equipment doesn’t put other tourists off using the lake. You’re sure there will be some way to recover it…</i> 

-> END
