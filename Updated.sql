-- MySQL dump 10.13  Distrib 8.0.19, for Win64 (x86_64)
--
-- Host: 127.0.0.1    Database: cibitdb
-- ------------------------------------------------------
-- Server version	8.0.19

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `articles`
--

DROP TABLE IF EXISTS `articles`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `articles` (
  `articleId` int NOT NULL AUTO_INCREMENT,
  `articleName` varchar(200) NOT NULL,
  `citationCount` int NOT NULL COMMENT 'function',
  `newCitations` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`articleId`),
  UNIQUE KEY `articleId_UNIQUE` (`articleId`),
  UNIQUE KEY `articlename_UNIQUE` (`articleName`)
) ENGINE=InnoDB AUTO_INCREMENT=8211 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `articles`
--

LOCK TABLES `articles` WRITE;
/*!40000 ALTER TABLE `articles` DISABLE KEYS */;
INSERT INTO `articles` VALUES (7361,'3d printing of shape memory polymers for flexible electronic devices',366,NULL),(7362,'designing biodegradable multiblock pcl/pla thermoplastic elastomers',365,NULL),(7363,'polyurethane-based polymeric materials and biomedical articles and pharmaceutical compositions utilizing the same',333,NULL),(7364,'biodegradable peo/pla block copolymers',271,NULL),(7365,'methods for reducing or eliminating post-surgical adhesion formation',250,NULL),(7366,'methods and compositions for reducing or eliminating post-surgical adhesion formation',0,NULL),(7367,'biodegradable polymeric materials based on polyether glycols, processes for the preparation thereof and surgical articles made therefrom',229,NULL),(7368,'polyester polyether block copolymers',207,NULL),(7369,'phase separation in poly (ethylene glycol)/poly (lactic acid) blends',202,NULL),(7370,'improved reverse thermo-responsive polymeric systems',175,NULL),(7371,'peo–ppo–peo-based poly (ether ester urethane) s as degradable reverse thermo-responsive multiblock copolymers',152,NULL),(7372,'biodegradable multiblock peo/pla thermoplastic elastomers: molecular design and properties',151,NULL),(7373,'dynamic mechanical and calorimetric analysis of compression‐molded plla of different molecular weights: effect of thermal treatments',151,NULL),(7374,'a study on the in vitro degradation of poly (lactic acid)',138,NULL),(7375,'amorphous and crystalline morphologies in glycolic acid and lactic acid polymers',130,NULL),(7376,'ethoxysilane-capped peo–ppo–peo triblocks: a new family of reverse thermo-responsive polymers',129,NULL),(7377,'biodegradable poly (ethylene oxide)/poly (ϵ‐caprolactone) multiblock copolymers',120,NULL),(7378,'smart hydrogels for in situ generated implants',105,NULL),(7379,'4d printing of shape memory‐based personalized endoluminal medical devices',102,NULL),(7380,'crosslinkable peo-ppo-peo-based reverse thermo-responsive gels as potentially injectable materials',99,NULL),(7381,'reverse thermo-responsive poly (ethylene oxide) and poly (propylene oxide) multiblock copolymers',98,NULL),(7382,'the effect of thermal history on the crystallinity of different molecular weight plla biodegradable polymers',93,NULL),(7383,'an essential role for the c-terminal domain of a dragline spider silk protein in directing fiber formation',90,NULL),(7384,'morphological study of biodegradable peo/pla block copolymers',88,NULL),(7385,'engineering of bio-hybrid materials by electrospinning polymer-microbe fibers',84,NULL),(7386,'prevention of retrosternal adhesion formation in a rabbit model using bioresorbable films of polyethylene glycol and polylactic acid',66,NULL),(7387,'application of radiation-grafted hydrogels as blood-contacting biomaterials',64,NULL),(7388,'novel synthetic selectively degradable vascular prostheses: a preliminary implantation study',63,NULL),(7389,'thermal expansion of kevlar fibres and composites',61,NULL),(7390,'evaluation of polyethylene glycol/polylactic acid films in the prevention of adhesions in the rabbit adhesion formation and reformation sidewall models',60,NULL),(7391,'responsive biomedical composites',55,NULL),(7392,'peptide-modified “smart” hydrogels and genetically engineered stem cells for skeletal tissue engineering',49,NULL),(7393,'responsive polymeric system',0,NULL),(7394,'poly (ethylene glycol)-poly (epsilon-caprolactone) block oligomers as injectable materials',49,NULL),(7395,'solution structure of the 3\'-5\'cyclic dinucleotide d (papa). a combined nmr, uv melting, and molecular mechanics study.',48,NULL),(7396,'biomedical polymers and polymer therapeutics',47,NULL),(7397,'compositional and structural analysis of pela biodegradable block copolymers degrading under in vitro conditions',47,NULL),(7398,'radiation‐grafted polymers for biomaterial applications. i. 2‐hydroxyethyl methacrylate: ethyl methacrylate grafting onto low density polyethylene films',44,NULL),(7399,'4d printing shape memory polymers for dynamic jewellery and fashionwear',43,NULL),(7400,'creep and wear behaviour of ethylene–butene copolymers reinforced by ultra-high molecular weight polyethylene fibres',40,NULL),(7401,'pericardial meshing: an effective method for prevention of pericardial adhesions and epicardial reaction after cardiac operations.',38,NULL),(7402,'novel reverse thermoresponsive injectable poly (ether carbonate) s',37,NULL),(7403,'rheology of thermoreversible hydrogels from multiblock associating copolymers',36,NULL),(7404,'repair of bone defect using bone marrow cells and demineralized bone matrix supplemented with polymeric materials',0,NULL),(7405,'engineering thermoresponsive polymeric nanoshells',35,NULL),(7406,'biodegradable pela block copolymers: in vitro degradation and tissue reaction',35,NULL),(7407,'tailoring lactide/caprolactone co-oligomers as tissue adhesives',31,NULL),(7408,'use of high-performance polyethylene fibres as a reinforcing phase in poly (methylmethacrylate) bone cement',31,NULL),(7409,'compliance and ultimate strength of composite arterial prostheses',30,NULL),(7410,'long-term evaluation of a new selectively biodegradable vascular graft coated with polyethylene oxide-polylactic acid for right ventricular conduit. an experimental study.',30,NULL),(7411,'utilization of composite laminate theory in the design of synthetic soft tissues for biomedical prostheses',29,NULL),(7412,'fatigue characterization of polyethylene fiber reinforced polyolefin biomedical composites',28,NULL),(7413,'polymeric compositions',27,NULL),(7414,'polymer based systems on tissue engineering, replacement and regeneration',27,NULL),(7415,'introducing a selectively biodegradable filament wound arterial prosthesis: a short‐term implantation study',27,NULL),(7416,'analysis of microembolic particles originating in extracorporeal circuits',27,NULL),(7417,'radiation‐grafted polymers for biomaterial applications. ii. the morphology and structure of 2‐hydroxyethyl methacrylate and ethyl methacrylate homopolymer grafts',26,NULL),(7418,'novel reverse thermo-sensitive block copolymers',11,NULL),(7419,'grafting reactions and heparin adsorption of poly (amidoamine)-grafted poly (urethane amide) s',23,NULL),(7420,'a proposal for a coefficient of hygroelasticity',23,NULL),(7421,'multi-component reverse thermo-sensitive polymeric systems',22,NULL),(7422,'chain-extended or crosslinked polyethylene oxide/polypropylene oxide/polyethylene oxide block polymer with optional polyester blocks',20,NULL),(7423,'sequential surface derivatization of pet films',20,NULL),(7424,'elastic and viscoelastic behavior of filament wound polyethylene fiber reinforced polyolefin composites',19,NULL),(7425,'temperature and ph responsive 3d printed scaffolds',18,NULL),(7426,'comparison of chondrogenesis in static and dynamic environments using a sff designed and fabricated pcl-peo scaffold',17,NULL),(7427,'chain extension as a strategy for the development of improved reverse thermo‐responsive polymers',17,NULL),(7428,'crosslinkable peo-ppo-peo triblocks as building blocks of thermo-responsive nanoshells',16,NULL),(7429,'chain-extended peo/ppo/peo block copolymer, optionally with polyester blocks, combined with cellular or bioactive material',16,NULL),(7430,'stiffness variability and stress-dependent elastic response of synthetic fibre-reinforced composites for biomedical applications',16,NULL),(7431,'introducing lactide-based biodegradable tissue adhesives',15,NULL),(7432,'mechanical behaviour of isolated pericardium: species, isotropy, strain rate and collagenase effect on pericardial tissue',15,NULL),(7433,'thermal expansion of aramid fibres',15,NULL),(7434,'surface oxidation of polyethylene fiber reinforced polyolefin biomedical composites and its effect on cell attachment',14,NULL),(7435,'elastic response of filament wound arterial prostheses under internal pressure',14,NULL),(7436,'new arterial prostheses by filament winding',14,NULL),(7437,'functionalization of poly [ethylene terephthalate) by means of glow-discharge-initiated polymerization of acrylic acid',13,NULL),(7438,'anisotropic hygroelastic behaviour of oriented poly (methyl methacrylate)',13,NULL),(7439,'poly (urethane)-crosslinked poly (hema) hydrogels',12,NULL),(7440,'the effect of the morphology on the hygroelastic behaviour of polyester and epoxy resins',12,NULL),(7441,'anisotropic hygroelastic behavior of poly (methyl methacrylate) under case ii diffusion',12,NULL),(7442,'surface tailoring of biomedical polymers: an ftir study',10,NULL),(7443,'deformation and failure of polymeric matrices under swelling conditions',10,NULL),(7444,'angular dependence of hygroelasticity in unidirectional glass-epoxy composites',10,NULL),(7445,'derivatization of a new poly (ether urethane amide) containing chemically active sites',9,NULL),(7446,'biodegradable adhesive compositions',6,NULL),(7447,'filament-wound composite soft tissue prostheses: controlling compliance and strength by water absorption and degradation',6,NULL),(7448,'compositions comprising bone marrow cells, demineralized bone matrix and various site-reactive polymers for use in the induction of bone and cartilage formation',5,NULL),(7449,'synthesis and derivatization of polybutadiene containing poly (ether urethane amide) s',5,NULL),(7450,'surface grafting thermoresponsive peo–ppo–peo chains',4,NULL),(7451,'novel polymeric compositions exhibiting reverse thermal gellation properties',3,NULL),(7452,'poly (ether urethane) oligomers as poly (hema) crosslinkers',4,NULL),(7453,'poly (ether urethane amide) s: a new family of biomedical elastomers',4,NULL),(7454,'in situ generated medical devices',3,NULL),(7455,'water triggered shape memory materials',3,NULL),(7456,'biocompatible polymeric delivery systems for sustained release of quinazolinones',3,NULL),(7457,'dynamic compliance measurements of synthetic biodegradable grafts and natural blood vessels',3,NULL),(7458,'modelling the anisotropic behaviour of filament wound vascular grafts',3,NULL),(7459,'novel segmented polyurethane amides for biomedical applications',3,NULL),(7460,'bio‐inspired multiple cycle healing and damage sensing in elastomer–magnet nanocomposites',2,NULL),(7461,'physical properties of polyacrylonitrile fibres treated with organotin compounds',2,NULL),(7462,'ophthalmic viscosurgical device',1,NULL),(7463,'reverse thermal gellation polymer of chain-extended optional polyester-terminated peo-ppo-peo',1,NULL),(7464,'polymeric nano-shells',1,NULL),(7465,'micro and macro characterization of peo‐ppo‐peo triblocks hydrogels',1,NULL),(7466,'multi-step surface tailoring of poly (ethylene terephthalate)',1,NULL),(7467,'remote control of biofouling by heating pdms/mnzn ferrite nanocomposites with an alternating magnetic field',0,NULL),(7468,'fibrinogen-based tissue adhesive patches',0,NULL),(7469,'frontiers in biomedical polymers conference series',0,NULL),(7470,'biodegradable polymer',0,NULL),(7471,'ready-made biomedical devices for in vivo welding',0,NULL),(7472,'intraluminal polymeric devices for the treatment of aneurysms',0,NULL),(7473,'designing a novel biodegradable cyanoacrylate-based tissue patch: o51',0,NULL),(7474,'a study of tracheal prostheses produced by composite laminate fabrication method in vitro: biodegradation and in-vivo implantation experiments',0,NULL),(7475,'in situ generated polymeric devices for the treatment of abdominal aortic aneurysm',0,NULL),(7476,'in situ generated scaffolds for tissue regeneration',0,NULL),(7477,'tailoring\" smart\" polymeric surfaces',0,NULL),(7478,'poly 648-bioactive polymer fibers for environmental remediation',0,NULL),(7479,'repair of osteochondral defect using bone marrow cells and demineralized bone matrix supplemented with polymeric materials',0,NULL),(7480,'synthesis and characterization of thermoreversible hydrogels from associating polymers',0,NULL),(7481,'scaffolding arterial tissue',0,NULL),(7482,'processos e composições para redução ou eliminação de formação de aderência pós-cirúrgica.',0,NULL),(7483,'improving the biodurability of implantable poly (ether urethane) s',0,NULL),(7484,'wound healing/plastic surgery-prevention of retrosternal adhesion formation in a rabbit model using bioresorbable films of polyethylene glycol and polylactic acid',0,NULL),(7485,'development of biodurable implantable elastomers',0,NULL),(7486,'r-234. effect of 5-methoxytryptamine, 5-methoxyindole-3-acetic acid and 5-methoxytryptophan on compensatory ovarian hypertrophy in rats',0,NULL),(7487,'comparison of repel (tm) and inteerceed (tm) in the reduction of adhesion formation in the presence of blood in rabbit models',0,NULL),(7488,'the editorial staff of bone is most grateful to all the members of the editorial board and to the scientists listed below for their help in reviewing manuscripts in 1996.',0,NULL),(7489,'the efficacy of repel™, ratio 3.0, a resorbable film of polyethylene glycol (peg)/polylactic acid (pla), in rabbits: f9. 1',0,NULL),(7490,'thermosensitive aggregates self-assembled by an asymmetric block copolymer of dendritic polyether and poly (n-isopropylacrylamide).',0,NULL),(7491,'self-restricted t cell recognition or donor hla-dr peptides during graft rejection',0,NULL),(7492,'synthesis of poly (ether urethane amide) segmented elastomers',0,NULL),(7493,'the mechanical response of filament wound arterial prostheses under internal pressure',0,NULL),(7494,'biomedical polymers: molecular design to clinical applications: international conference',0,NULL),(7495,'poly (ether urethane amide) s-a new polyurethane elastomer for biomedical use. 1. study of the segmented poly (ether urethane amide) synthesis',0,NULL),(7496,'crystallizability and degradation of different poly (lactic acid) samples',0,NULL),(7497,'poly(amidoamine) grafted poly(urethane amide)s for blood-contacting applications. i. grafting reaction and heparin adsorption',0,NULL),(7498,'poly (ether urethane amide) s: a new polyurethane elastomer. i. study of the segmented poly (ether urethane amide) synthesis',0,NULL),(7499,'clinical implant materials, edited by g. heimke, u. soltesz and ajc lee, 37 advances in biomaterials, volume 9, elsevier science publishers bv, amsterdam, 1990—printed in the …',0,NULL),(7500,'the utilization of composite laminate theory in the design of filament wound synthetic soft tissues for biomedical prostheses',0,NULL),(7501,'new tailor-made biodegradable polymeric materials',0,NULL),(7502,'the past years have witnessed a growing interest in the development of',0,NULL),(7503,'scanning electron microscopic observations on intimal growth in biodegradable-material-impregnated knitted dacron, and in woven dacron extracardial conduits',0,NULL),(7504,'polyether isocyanurate elastomers',0,NULL),(7505,'the effect of the morphology on the hydroelastic of polyester and epoxy resins',0,NULL),(7506,'a stress transfer model for the deformation and failure of polymeric matrices under swelling conditions',0,NULL),(7507,'deformations of polymers and composites under swelling conditions',0,NULL),(7508,'3d printing environmentally responsive medical devices',0,NULL),(7509,'caprani a see bernabeu p, 258 carnot f see riquet m, 518 carrera san martin a see garcia paez jm, 186 cha y and pitt cg, the biodegradability of polyester blends, 108',0,NULL),(7510,'3. chaistel',0,NULL),(7511,'injectable polymer-calcium phosphate composites for artificial bone substitutes',0,NULL),(7512,'elastic, viscoelastic and fatigue behavior of polyethylene filament wound polyolefin composites',0,NULL),(7513,'engineering thermo-responsive nanosuitcases',0,NULL),(7514,'reverse thermo-responsive polymers for in situ generated implants',0,NULL),(7515,'an access control model for data security in online social networks based on role and user credibility',4,NULL),(7516,'an information-flow control model for online social networks based on user-attribute credibility and connection-strength factors',4,NULL),(7517,'traffic control in a smart intersection by an algorithm with social priorities',3,NULL),(7518,'mssp for 2-d sets with unknown parameters and a cryptographic application',2,NULL),(7519,'finding the most efficient paths between two vertices in a knapsack-item weighted graph',2,NULL),(7520,'generating error-correcting codes based on tower of hanoi configuration graphs',2,NULL),(7521,'real life applicative timing algorithm for a smart junction with social priorities and multiple parameters',1,NULL),(7522,'applying pbl to teaching robotics',1,NULL),(7523,'managing large distributed dynamic graphs for smart city network applications',0,NULL),(7524,'handling traffic loads in a smart junction by social priorities',0,NULL),(7525,'a role and trust access control model for preserving privacy and image anonymization in social networks',0,NULL),(7526,'an mst-based information flow model for security in online social networks',0,NULL),(7527,'optimal paths of knapsack-set vertices on a weight-independent graph',0,NULL),(7528,'implementing efficient paths in a knapsack-item weighted graph on iot architecture',0,NULL),(7529,'a complex problem of knapsack and shortest paths on weighted graphs',0,NULL),(7530,'a two-step algorithm for a complex problem of shortest paths on weighted graphs and 0-1 knapsack',0,NULL),(7531,'comparative analysis of master-slave latches and flip-flops for high-performance and low-power systems',797,NULL),(7532,'improved sense-amplifier-based flip-flop: design and measurements',501,NULL),(7533,'a method for speed optimized partial product reduction and generation of fast parallel multipliers using an algorithmic approach',416,NULL),(7534,'pass-transistor adiabatic logic using single power-clock supply',260,NULL),(7535,'clocked cmos adiabatic logic with integrated single-phase power-clock supply',226,NULL),(7536,'digital system clocking: high-performance and low-power aspects',216,NULL),(7537,'an algorithmic and novel design of a leading zero detector circuit: comparison with logic synthesis',211,NULL),(7538,'instruction control mechanism for a computing system with register renaming, map table and queues indicating available registers',182,NULL),(7539,'improving multiplier design by using improved column compression tree and optimized final adder in cmos technology',172,NULL),(7540,'optimal circuits for parallel multipliers',166,NULL),(7541,'comparison of high-performance vlsi adders in the energy-delay space',124,NULL),(7542,'instruction prefetch buffer control',120,NULL),(7543,'conditional pre-charge techniques for power-efficient dual-edge clocking',113,NULL),(7544,'a 110 gops/w 16-bit multiplier and reconfigurable pla loop in 90-nm cmos',109,NULL),(7545,'integrated power clock generators for low energy logic',108,NULL),(7546,'clocking and clocked storage elements in a multi-gigahertz environment',105,NULL),(7547,'dual-edge triggered storage elements and clocking strategy for low-power systems',99,NULL),(7548,'the computer engineering handbook',94,NULL),(7549,'design-performance trade-offs in cmos-domino logic',94,NULL),(7550,'some optimal schemes for alu implementation in vlsi technology',93,NULL),(7551,'energy-delay estimation technique for high-performance microprocessor vlsi adders',91,NULL),(7552,'hybrid latch flip-flop with improved power efficiency',0,NULL),(7553,'sense amplifier-based flip-flop',87,NULL),(7554,'general data-path organization of a mac unit for vlsi implementation of dsp processors',2,NULL),(7555,'a general method in synthesis of pass-transistor circuits',80,NULL),(7556,'delay optimization of carry-skip adders and block carry-lookahead adders using multidimensional dynamic programming',76,NULL),(7557,'energy-efficient design methodologies: high-performance vlsi adders',71,NULL),(7558,'high performance universal multiplier circuit',68,NULL),(7559,'on testability of cmos-domino logic',66,NULL),(7560,'conditional techniques for low power consumption flip-flops',65,NULL),(7561,'low-and ultra low-power arithmetic units: design and comparison',61,NULL),(7562,'on implementing addition in vlsi technology',58,NULL),(7563,'energy efficient implementation of parallel cmos multipliers with improved compressors',57,NULL),(7564,'design strategies for optimal hybrid final adders in a parallel multiplier',57,NULL),(7565,'consistent precharge circuit for cascode voltage switch logic',55,NULL),(7566,'evaluation of booth encoding techniques for parallel multiplier implementation',51,NULL),(7567,'a clock skew absorbing flip-flop',50,NULL),(7568,'clocked cmos adiabatic logic with single ac power supply',50,NULL),(7569,'an on-line square root algorithm',50,NULL),(7570,'high-performance energy-efficient microprocessor design',4,NULL),(7571,'dynamic flip-flop with improved power',0,NULL),(7572,'energy optimization of pipelined digital systems using circuit sizing and supply scaling',47,NULL),(7573,'high-speed vlsi arithmetic units: adders and multipliers',6,NULL),(7574,'the effect of the system specification on the optimal selection of clocked storage elements',46,NULL),(7575,'delay optimization of carry-skip adders and block carry-lookahead adders.',46,NULL),(7576,'clocked cmos adiabatic logic with integrated single-phase power-clock supply: experimental results',43,NULL),(7577,'high-performance system design: circuits and logic',41,NULL),(7578,'pass-transistor dual value logic for low-power cmos',41,NULL),(7579,'a test circuit for measurement of clocked storage element characteristics',40,NULL),(7580,'a unified approach in the analysis of latches and flip-flops for low-power systems',40,NULL),(7581,'high performance pipelined data path for a media processor',38,NULL),(7582,'differential and pass-transistor cmos logic for high-performance systems',38,NULL),(7583,'efficient mapping of addition recurrence algorithms in cmos',37,NULL),(7584,'timing characterization of dual-edge triggered flip-flops',37,NULL),(7585,'flip-flop',37,NULL),(7586,'an implementation algorithm and design of a novel leading zero detector circuit',37,NULL),(7587,'a low power symmetrically pulsed dual edge-triggered flip-flop',36,NULL),(7588,'application of logical effort techniques for speed optimization and analysis of representative adders',36,NULL),(7589,'implementing multiply-accumulate operation in multiplication time',36,NULL),(7590,'digital design and fabrication',34,NULL),(7591,'multiplexer based adder for media signal processing',34,NULL),(7592,'analysis of booth encoding efficiency in parallel multipliers using compressors for reduction of partial products',33,NULL),(7593,'clocking in multi-ghz environment',0,NULL),(7594,'multiplier structures for low power applications in deep-cmos',31,NULL),(7595,'energy minimization method for optimal energy-delay extraction',30,NULL),(7596,'comparative analysis of double-edge versus single-edge triggered clocked storage elements',30,NULL),(7597,'design and analysis of fast carry-propagate adder under non-equal input signal arrival profile',28,NULL),(7598,'register selection mechanism and organization of an instruction prefetch buffer',28,NULL),(7599,'application of logical effort on delay analysis of 64-bit static carry-lookahead adder',27,NULL),(7600,'application of logical effort on design of arithmetic blocks',25,NULL),(7601,'design strategies for the final adder in a parallel multiplier',24,NULL),(7602,'multithreaded decoupled architecture',24,NULL),(7603,'development and synthesis method for pass-transistor logic family for high-speed and low power cmos',24,NULL),(7604,'method and system for improving speed in a flip-flop',23,NULL),(7605,'comparative analysis of latches and flip-flops for high-performance systems',22,NULL),(7606,'an integrated multiplier for complex numbers',22,NULL),(7607,'improved cla scheme with optimized delay',22,NULL),(7608,'low-power soft error hardened latch',21,NULL),(7609,'efficient realizations of squaring circuit and reciprocal used in adaptive sample rate notch filters',21,NULL),(7610,'64-bit media adder',20,NULL),(7611,'design strategies for optimal multiplier circuits',19,NULL),(7612,'simple and efficient cmos circuit for fast vlsi adder realization',19,NULL),(7613,'multiplier design utilizing improved column compression tree and optimized final adder in cmos technology',18,NULL),(7614,'soft error filtered and hardened latch',17,NULL),(7615,'a 90 nm 1 ghz 22 mw 16/spl times/16-bit 2\'s complement multiplier for wireless baseband',17,NULL),(7616,'performance comparison of vlsi adders using logical effort',16,NULL),(7617,'method and system for reducing hazards in a flip-flop',15,NULL),(7618,'multiplexer based parallel n-bit adder circuit for high speed processing',14,NULL),(7619,'multiplier circuit having an optimized booth encoder/selector',14,NULL),(7620,'partitioned shift right logic circuit having rounding support',14,NULL),(7621,'an ecl gate with improved speed and low power in a bicmos process',14,NULL),(7622,'energy efficiency of power-gating in low-power clocked storage elements',13,NULL),(7623,'design and optimization of sense-amplifier-based flip-flops',13,NULL),(7624,'synthesis of high-speed pass-transistor logic',13,NULL),(7625,'testability enhancement of vlsi using circuit structures',13,NULL),(7626,'analysis of clocked timing elements for dynamic voltage scaling effects over process parameter variation',12,NULL),(7627,'evaluation of booth\'s algorithm for implementation in parallel multipliers',0,NULL),(7628,'circuit sizing and supply-voltage selection for low-power digital circuit design',11,NULL),(7629,'area-time optimal adder with relative placement generator',11,NULL),(7630,'a programmable data-path for mpeg-4 and natural hybrid video coding',11,NULL),(7631,'optimal designs for multipliers and multiply-accumulators',11,NULL),(7632,'test generation for fet switching circuits.',11,NULL),(7633,'switching activity calculation of vlsi adders',10,NULL),(7634,'reduced-complexity sequence detection',10,NULL),(7635,'comments on\" leading-zero anticipatory logic for high-speed floating point addition\"[with reply]',10,NULL),(7636,'exploration of switching activity behavior of addition algorithms',9,NULL),(7637,'jitter analysis of nonautonomous mos current-mode logic circuits',9,NULL),(7638,'an efficient transistor optimizer for custom circuits',9,NULL),(7639,'clocking and clocked storage elements in multi-ghz environment',9,NULL),(7640,'algorithmic design of a hierarchical and modular leading zero detector circuit',9,NULL),(7641,'conditional pre-charge method and system',8,NULL),(7642,'architectural tradeoffs for low power',8,NULL),(7643,'implementation of adaptive sample rate kwan-martin notch filter using efficient realizations of reciprocal and squaring circuit',8,NULL),(7644,'an asic macro cell multiplier for complex numbers',8,NULL),(7645,'clocked storage elements robust to process variations',7,NULL),(7646,'logic style comparison for ultra low power operation in 65nm technology',7,NULL),(7647,'logic style comparison for ultra low power applications',7,NULL),(7648,'multi-ghz systems clocking',7,NULL),(7649,'low-energy logic circuit techniques for multiple valued logic',7,NULL),(7650,'determination of optimal sizes for a first and second level sram-dram on-chip cache combination',0,NULL),(7651,'optimization and speed improvement analysis of carry-lookahead adder structure',7,NULL),(7652,'design for testability of vlsi structures through the use of circuit techniques.',7,NULL),(7653,'methodology for energy-efficient digital circuit sizing: important issues and design limitations',6,NULL),(7654,'energy-delay characteristics of cmos adders',6,NULL),(7655,'energy optimization of high-performance circuits',6,NULL),(7656,'vlsi implementation of early branch prediction circuits for high performance computing',6,NULL),(7657,'issues in cpu-coprocessor communication and synchronization.',6,NULL),(7658,'energy-delay space analysis for clocked storage elements under process variations',5,NULL),(7659,'low-power aspects of different adder topologies',5,NULL),(7660,'a hierarchical and modular circuit implementing leading zero detector for a high performance floating-point processor',5,NULL),(7661,'minimizing energy by achieving optimal sparseness in parallel adders',4,NULL),(7662,'design methodology for clocked storage elements robust to process variations',4,NULL),(7663,'design of energy efficient digital circuits',1,NULL),(7664,'architectural considerations for energy efficiency',4,NULL),(7665,'optimal sequencing energy allocation for cmos integrated systems',0,NULL),(7666,'instruction set architecture for multimedia signal processing',4,NULL),(7667,'new pipelined architecture for dsp',4,NULL),(7668,'logic synthesis for pass-transistor design',4,NULL),(7669,'simulations of interacting many body systems using p4',4,NULL),(7670,'considerations for design of a complex multiplier',4,NULL),(7671,'vlsi chip architecture for real-time ambiguity function computation',4,NULL),(7672,'optimal transistor sizing and voltage scaling for minimal energy use at fixed performance',3,NULL),(7673,'encryption processor for performing accelerated computations to establish secure network sessions connections',3,NULL),(7674,'energy-efficient optimization of the viterbi acs unit architecture',3,NULL),(7675,'a method for energy optimization of digital pipelined systems',3,NULL),(7676,'future directions in clocking multi-ghz systems',3,NULL),(7677,'partitioned branch condition resolution logic',0,NULL),(7678,'reduced-complexity sequence detection for e/sup 2/pr4 magnetic recording channel',3,NULL),(7679,'design for low power',3,NULL),(7680,'reduced instruction set computers',3,NULL),(7681,'design and experimental verification of a cmos adiabatic logic with single-phase power-clock supply',3,NULL),(7682,'ss liu,“a method far speed optimired partial product reduction and generation of fast parallel multipliers using an algorithmic appmacy’',3,NULL),(7683,'reconfigurable processor for real-time adaptive sample rate notch filtering',3,NULL),(7684,'logic synthesis for asic: a guided algorithmic approach',3,NULL),(7685,'new ecl gate in bifet process',3,NULL),(7686,'vlsi architecture of a real-time wigner distribution processor for acoustic signals',3,NULL),(7687,'design of a link-controller architecture for multiple serial link protocols',2,NULL),(7688,'clocked storage elements in digital systems',2,NULL),(7689,'energy-delay tradeoffs in cmos digital circuits design',2,NULL),(7690,'issues in system on the chip clocking',2,NULL),(7691,'design of power efficient vlsi arithmetic: speed and power trade-offs',2,NULL),(7692,'impact of architecture extensions for media signal processing on data-path organization',2,NULL),(7693,'highperformance arithmetic units',2,NULL),(7694,'a single-phase clock high-performance bicmos latch',2,NULL),(7695,'pass-transistor logic family for high-speed and low-power cmos',2,NULL),(7696,'architectural study for an integrated fixed and floating-point vlsi-asic processor',2,NULL),(7697,'architecture for single-chip asic processor with integrated floating point unit',2,NULL),(7698,'soft-error hardened redundant triggered latch',1,NULL),(7699,'a quick method for energy optimized gate sizing of digital circuits',1,NULL),(7700,'low-power soft error hardened latch: patmos 2009 workshop',1,NULL),(7701,'a new methodology for power-aware transistor sizing: free power recovery (fpr)',1,NULL),(7702,'energy-delay space exploration of clocked storage elements using circuit sizing',1,NULL),(7703,'a new model for timing jitter caused by device noise in current-mode logic frequency dividers',1,NULL),(7704,'fir filter for adaptive equalization in prml read channels',1,NULL),(7705,'computer arithmetic for the processing of media signals',1,NULL),(7706,'computational requirements for media signal processing',1,NULL),(7707,'low voltage bicmos tspc latch for high performance digital systems',1,NULL),(7708,'monte carlo and molecular dynamics simulations using p4',0,NULL),(7709,'a study of i/o architecture for high performance next generation computers',0,NULL),(7710,'submissions: https://mc. manuscriptcentral. com/micro-cs author guidelines',0,NULL),(7711,'2014 index ieee circuits and systems magazine vol. 14',0,NULL),(7712,'message from the vice president for technical activities',0,NULL),(7713,'circuit topology considerations for energy efficient design of data-driven systems',0,NULL),(7714,'2012 index ieee circuits and systems magazine vol. 12',0,NULL),(7715,'editorial management molly gamborg business operations editor ed zintel contributing editors',0,NULL),(7716,'business operations editor ed zintel contributing editors cheryl baltes, stacy burns, bob carlson',0,NULL),(7717,'computing at the ultimate low-energy limits',0,NULL),(7718,'editorial management joan taylor business operations editor ed zintel contributing editors',0,NULL),(7719,'methodology for energy-efficient design of digital circuits',0,NULL),(7720,'editorial management joan taylor magazine business operations editor ed zintel contributing editor',0,NULL),(7721,'director, products & services evan butterfield magazine business operations manager robin baldwin senior editorial services manager',0,NULL),(7722,'editorial management margaret weatherford associate staff editor ed zintel contributing editors',0,NULL),(7723,'developing a fast and inexpensive low power design strategy',0,NULL),(7724,'managing editor margaret weatherford associate staff editor ed zintel contributing editors',0,NULL),(7725,'reduced instruction set computing',0,NULL),(7726,'circuit design style for energy efficiency: lsdl and compound domino',0,NULL),(7727,'microprocessor design',0,NULL),(7728,'acs el',0,NULL),(7729,'new generation of predictive technology model for sub-45 nm early design exploration.',0,NULL),(7730,'clocking multi-ghz systems',0,NULL),(7731,'multiplier energy reduction through bypassing of partial products.',0,NULL),(7732,'microprocessor examples',0,NULL),(7733,'simulation techniques',0,NULL),(7734,'highperformance system issues',0,NULL),(7735,'timing and energy parameters',0,NULL),(7736,'pipelining and timing analysis',0,NULL),(7737,'multi-ghz systems clocking invited paper',0,NULL),(7738,'lowenergy system issues',0,NULL),(7739,'theory of clocked storage elements',0,NULL),(7740,'energy efficient microarchitectural techniques',0,NULL),(7741,'embedded tutorial 1: future directions in clocking multi-ghz systems',0,NULL),(7742,'design flow and cad tools for asynchronous design of sequential library cells',0,NULL),(7743,'embedded tutorial: clocked timing elements for high-performance and low-power vlsi systems',0,NULL),(7744,'digital arithmetic',0,NULL),(7745,'principles of cmos vlsi design.',0,NULL),(7746,'86.1 number systems',0,NULL),(7747,'clock subsystem',0,NULL),(7748,'advances in cmos circuits',0,NULL),(7749,'clocking and latches©',0,NULL),(7750,'early branch prediction circuit for high performance digital signal processors',0,NULL),(7751,'low-power logic styles: cmos versus pass-transistor logic.',0,NULL),(7752,'a uniﬁed approach in the analysis of latches and flip-flops for low-power systems',0,NULL),(7753,'computer organization: architecture',0,NULL),(7754,'special issue on vlsi arithmetic and implementations-introduction',0,NULL),(7755,'foreword for march 1996 issue',0,NULL),(7756,'signal processing systems for signal, image, and video technology',0,NULL),(7757,'isscc 2003/session 19/processor building blocks/paper 19.5',0,NULL),(7758,'asynchronous circuit-design for vlsi signal-processing-introduction',0,NULL),(7759,'a low-power microprocessor based on resonant energy.',0,NULL),(7760,'some optimal schemes for alu implementation',0,NULL),(7761,'rapid turn-around design style and technology: impact on computer architecture',0,NULL),(7762,'the cily college of new york* 1bm tj watson research center department of electrical engineering po box 218 new york, ny 10031,(212) 690-6685 yorktown heights, ny 10598,(914 …',0,NULL),(7763,'improving testability by using additional circuits',0,NULL),(7764,'jaeseok kim (yonsei university)',0,NULL),(7765,'steering committee board',0,NULL),(7766,'the institute of electrical and electronics engineers, inc. officers',0,NULL),(7767,'message from general chairs',0,NULL),(7768,'dynamic cmos circuits',0,NULL),(7769,'power-delay characteristics of cmos adders',0,NULL),(7770,'reduced-complexity sequence detection fore “pr4magnetic recording channel',0,NULL),(7771,'steering committee members',0,NULL),(7772,'symposium committee',0,NULL),(7773,'peter kornerup, university of southern denmark, denmark jean-michel muller, lip/arénaire ens lyon, france elisardo antelo, university of santiago de compostela, spain jean …',0,NULL),(7774,'reconfigurable multimedia datapath for low cost media processors',0,NULL),(7775,'members-at-large',0,NULL),(7776,'article#: inspec accession number',0,NULL),(7777,'i. bahar (brown university) m. balakrishnan (iit delhi) l. benini (university of bologna) l. breems (philips)',0,NULL),(7778,'2008 ieee dallas circuits and systems workshop organizing committee',0,NULL),(7779,'3ar1ury rxu11uu miriam leeser',0,NULL),(7780,'13th ieee symposium on computer arithmetic asilomar, california, usa: july 6-july 9, 1997',0,NULL),(7781,'arith-20',0,NULL),(7782,'tp 16.5 sense amplifier-based flip-flop',0,NULL),(7783,'a 10.7-mhz self-calibrated switched-capacitor-based multibit second-order bandpass modulator with on-chip switched buffer.................................. v. colonna, g …',0,NULL),(7784,'development and analysis of logic and associated timing and latches for systems operating in above 1ghz environment',0,NULL),(7785,'syste1\\/i for rapid prototyping of application specific signal processors for asic implementation',0,NULL),(7786,'program subcommittee chairs',0,NULL),(7787,'low voltage bi cmos tspc latch for high performance digital systems',0,NULL),(7788,'program co-chairs',0,NULL),(7789,'elisardo antelo, university of santiago de compostela, spain jean-claude bajard, lip6, cnrs, université pierre et marie curie, france javier d. bruguera, university of santiago …',0,NULL),(7790,'technical program co-chairs',0,NULL),(7791,'steering committee chair',0,NULL),(7792,'methodology for energy-efficient digital circuit',0,NULL),(7793,'clocked storage elements in high-performance and low-power systems',0,NULL),(7794,'quantitative analysis and computational complexity of media signal processing',0,NULL),(7795,'dynamic and pass-transistor logic',0,NULL),(7796,'radio link quality estimation in wireless sensor networks: a survey',627,NULL),(7797,'iterative computer algorithms: and their applications in engineering',603,NULL),(7798,'vlsi physical design automation: theory and practice',562,NULL),(7799,'evolutionary algorithms, simulated annealing and tabu search: a comparative study',235,NULL),(7800,'f-lqe: a fuzzy link quality estimator for wireless sensor networks',165,NULL),(7801,'quality of experience of voip service: a survey of assessment approaches and open issues',100,NULL),(7802,'a comparative simulation study of link quality estimators in wireless sensor networks',99,NULL),(7803,'radiale: a framework for designing and assessing link quality estimators in wireless sensor networks',70,NULL),(7804,'timing constraints for correct performance',70,NULL),(7805,'a new authentication protocol for gsm networks',0,NULL),(7806,'reliable link quality estimation in low-power wireless networks and its impact on tree-routing',62,NULL),(7807,'cyber-physical systems clouds: a survey',56,NULL),(7808,'qos-driven multicast tree generation using tabu search',55,NULL),(7809,'bounds on net delays for vlsi circuits',54,NULL),(7810,'fuzzy simulated evolution algorithm for multi-objective optimization of vlsi placement',48,NULL),(7811,'confidentiality and integrity for data aggregation in wsn using homomorphic encryption',45,NULL),(7812,'topology design of switched enterprise networks using a fuzzy simulated evolution algorithm',32,NULL),(7813,'radio link quality estimation in low-power wireless networks',29,NULL),(7814,'survey on rpl enhancements: a focus on topology, security and mobility',27,NULL),(7815,'multi-hop leach based cross-layer design for large scale wireless sensor networks',27,NULL),(7816,'on the adequacy of tabu search for global robot path planning problem in grid environments.',27,NULL),(7817,'external radio interference',26,NULL),(7818,'performance evaluation of encryption algorithm for wireless sensor networks',26,NULL),(7819,'timing-influenced general-cell genetic floorplanner',26,NULL),(7820,'ikm-an identity based key management scheme for heterogeneous sensor networks.',25,NULL),(7821,'critical path issue in vlsi design',25,NULL),(7822,'a distributed market-based algorithm for the multi-robot assignment problem',24,NULL),(7823,'timing influenced force directed floorplanning',0,NULL),(7824,'is qoe estimation based on qos parameters sufficient for video quality assessment?',23,NULL),(7825,'a testbed for the evaluation of link quality estimators in wireless sensor networks',21,NULL),(7826,'a parallel tabu search algorithm for vlsi standard-cell placement',21,NULL),(7827,'secure data transmission protocol for medical wireless sensor networks',19,NULL),(7828,'fl-mtsp: a fuzzy logic approach to solve the multi-objective multiple traveling salesman problem for multi-robot systems',18,NULL),(7829,'design and performance analysis of global path planning techniques for autonomous mobile robots in grid environments',18,NULL),(7830,'adapting tls handshake protocol for heterogenous ip-based wsn using identity based cryptography',18,NULL),(7831,'locality-aware chord over mobile ad hoc networks',18,NULL),(7832,'voicing-aware parametric speech quality models over voip networks',17,NULL),(7833,'parallelizing tabu search on a cluster of heterogeneous workstations',0,NULL),(7834,'secure data aggregation with mac authentication in wireless sensor networks',16,NULL),(7835,'a pairing identity based key management protocol for heterogeneous wireless sensor networks',16,NULL),(7836,'iterative heuristics for multiobjective vlsi standard cell placement',16,NULL),(7837,'a fuzzy approach for pertinent information extraction from web resources',14,NULL),(7838,'fuzzy evolutionary hybrid metaheuristic for network topology design',14,NULL),(7839,'performance driven standard-cell placement using the genetic algorithm',14,NULL),(7840,'timing analysis of cell-based vlsi designs',14,NULL),(7841,'establishing pairwise keys in heterogeneous two-tiered wireless sensor networks',13,NULL),(7842,'fuzzy evolutionary algorithm for vlsi placement',13,NULL),(7843,'adaptive bias simulated evolution algorithm for placement',0,NULL),(7844,'proactive maintenance in rpl for 6lowpan',12,NULL),(7845,'fuzzy simulated evolution for power and performance optimization of vlsi placement',12,NULL),(7846,'fuzzy simulated evolution algorithm for topology design of campus networks',12,NULL),(7847,'timing issues in cell-based vlsi design.',12,NULL),(7848,'a cmos voltage-controlled linear resistor with wide dynamic range',12,NULL),(7849,'impact of one-timer/n-timer object classification on the performance of web cache replacement algorithms',11,NULL),(7850,'an efficient source authentication scheme in wireless sensor networks',11,NULL),(7851,'mlcc: a new hash‐chained mechanism for multicast source authentication',11,NULL),(7852,'design and implementation of a software bridge with packet filtering and statistics collection functions',11,NULL),(7853,'qoe-driven video streaming system over cloud-based vanet',10,NULL),(7854,'lightweight secure group communications for resource constrained devices',10,NULL),(7855,'lightweight source authentication mechanisms for group communications in wireless sensor networks',10,NULL),(7856,'adaptive playout scheduling algorithm tailored for real-time packet-based voice conversations over wireless ad-hoc networks',10,NULL),(7857,'fuzzified iterative algorithms for performance driven low power vlsi placement',10,NULL),(7858,'cmos/bicmos mixed design using tabu search',10,NULL),(7859,'timing driven genetic algorithm for standard-cell placement',10,NULL),(7860,'predictive tools in vlsi system design: timing aspects',10,NULL),(7861,'security architecture for at-home medical care using wireless sensor network',9,NULL),(7862,'an efficient secure data aggregation scheme for wireless sensor networks',9,NULL),(7863,'parametric speech quality models for measuring the perceptual effect of network delay jitter',9,NULL),(7864,'xlengine: a cross-layer autonomic architecture with network wide knowledge for qos support in wireless networks',9,NULL),(7865,'tabu search based circuit optimization',9,NULL),(7866,'timing constraints on signal propagation in vlsi',9,NULL),(7867,'multi-objective virtual machine placement algorithm based on particle swarm optimization',8,NULL),(7868,'predictive handoff mechanism for video streaming in a cloud-based urban vanet',8,NULL),(7869,'efficiency of the rpl repair mechanisms for low power and lossy networks',8,NULL),(7870,'provisioning qoe over converged networks: issues and challenges',8,NULL),(7871,'an efficient scheme for key pre-distribution in wireless sensor networks',8,NULL),(7872,'fuzzy simulated evolution algorithm for vlsi cell placement',0,NULL),(7873,'timing-driven global routing for standard-cell vlsi design',8,NULL),(7874,'iterative algorithms and their applications in engineering',8,NULL),(7875,'lightweight and confidential data aggregation in healthcare wireless sensor networks',7,NULL),(7876,'efficient mobility management in 6lowpan wireless sensor networks',7,NULL),(7877,'secure data aggregation in wireless sensor networks',7,NULL),(7878,'performance evaluation of key disclosure delay-based schemes in wireless sensor networks',0,NULL),(7879,'loopy belief propagation in bayesian networks: origin and possibilistic perspectives',7,NULL),(7880,'rmlcc: recovery-based multi-layer connected chain mechanism for multicast source authentication',7,NULL),(7881,'equation-based end-to-end single-rate multicast congestion control',7,NULL),(7882,'tfmcc-based on a new equation for multicast rate control',7,NULL),(7883,'a fuzzy evolutionary algorithm for topology design of campus networks.',7,NULL),(7884,'a clustering market-based approach for multi-robot emergency response applications',6,NULL),(7885,'global robot path planning using ga for large grid maps: modelling, performance and experimentation',6,NULL),(7886,'cgk: a collaborative group key management scheme',6,NULL),(7887,'a fast handover scheme for proxy-based mobility in wireless sensor networks',6,NULL),(7888,'an analytical model for the performance evaluation of stack‐based web cache replacement algorithms',6,NULL),(7889,'demo abstract: radiale: a framework for benchmarking link quality estimators',6,NULL),(7890,'improving chord network performance using geographic coordinates',6,NULL),(7891,'improving the performance of end-to-end single rate multicast congestion control',6,NULL),(7892,'an adaptive mechanism for end-to-end multirate multicast congestion control',6,NULL),(7893,'local view\'s dissemination for a network wide optimization to improve qos in ad hoc networks',6,NULL),(7894,'iterative converging algorithms for computing bounds on durations of activities in pert and pert-like models',6,NULL),(7895,'net criticality revisited: an effective method to improve timing in physical design',6,NULL),(7896,'an evolutionary algorithm for network topology design',6,NULL),(7897,'prelayout timing analysis of cell-based vlsi designs',6,NULL),(7898,'medical usage of an expert system for recognizing chaos',6,NULL),(7899,'cross-layer approach based energy minimization for wireless sensor networks',5,NULL),(7900,'overview of link quality estimation',5,NULL),(7901,'impact of non-qos related parameters on video qoe',5,NULL),(7902,'single-ended parametric voicing-aware models for live assessment of packetized voip conversations',5,NULL),(7903,'evolutionary algorithm for provisioning vpn trees based on pipe and hose workload models',5,NULL),(7904,'nida: a parametric vocal quality assessment algorithm over transient connections',5,NULL),(7905,'a cross-layer autonomic architecture for qos support in wireless networks',5,NULL),(7906,'wireless routing protocol based on trust evaluation',5,NULL),(7907,'an approximate propagation algorithm for product-based possibilistic networks.',5,NULL),(7908,'evom: a software based platform for voice transmission and quality assessment over wireless ad-hoc networks',5,NULL),(7909,'xlengine: une architecture cross-layer modele pour le support de la qos dans les reseaux sans fil ieee 802.11',5,NULL),(7910,'adaptive playback algorithm for interactive audio streaming over wireless ad-hoc networks',5,NULL),(7911,'fuzzy genetic algorithms for floorplanning',5,NULL),(7912,'a fast handover protocol for 6lowpan wireless mobile sensor networks',4,NULL),(7913,'cloudlets architecture for wireless sensor network',4,NULL),(7914,'hose workload based exact algorithm for the optimal design of virtual private networks',4,NULL),(7915,'secure and energy-efficient data aggregation for wireless sensor networks',4,NULL),(7916,'exploiting locality using geographic coordinates and semantic proximity in chord',4,NULL),(7917,'efficient sender authentication and signing of multicast streams over lossy channels',4,NULL),(7918,'building cost effective lower layer vpns: the ilec/clec paradox',4,NULL),(7919,'qos-par: a routing protocol for wireless ad hoc networks using a cross-layer autonomic architecture',4,NULL),(7920,'a local view management protocol for network-wide view construction in wireless networks',4,NULL),(7921,'on the use of guaranteed possibility measures in possibilistic networks',4,NULL),(7922,'wireless routing protocol based on auto--learning algorithm',4,NULL),(7923,'use of conditional random field to extract pertinent information from web resources',4,NULL),(7924,'loop based scheduling for high level synthesis',4,NULL),(7925,'a collaborative key management scheme for distributed smart objects',3,NULL),(7926,'video streaming challenges over vehicular ad-hoc networks in smart cities',3,NULL),(7927,'lightweight trust model with high longevity for wireless sensor networks.',3,NULL),(7928,'performance analysis of aodv and aomdv over smac and ieee 802.15. 4 in wireless multimedia sensor network',3,NULL),(7929,'performance evaluation of ec-elgamal encryption algorithm for wireless sensor networks',3,NULL),(7930,'from constant traffic matrices to hose workload model for vpn tree design',3,NULL),(7931,'perceptual quality assessment of packet-based vocal conversations over wireless networks: methodologies and applications',3,NULL),(7932,'demo abstract: a testbed for the evaluation of link quality estimators in wsns',3,NULL),(7933,'benefits of a pure layer 2 security approach in metro ethernet',3,NULL),(7934,'improving end-to-end multicast rate control in wireless networks',3,NULL),(7935,'a self-tuned quality-aware de-jittering buffer scheme of packetized voice conversations',3,NULL),(7936,'parallel tabu search in a heterogeneous environment',3,NULL),(7937,'a parallel-tree switch architecture for atm networks',0,NULL),(7938,'fuzzy-logic-based multi-objective best-fit-decreasing virtual machine reallocation',2,NULL),(7939,'resource management in cloud data centers: a survey',2,NULL),(7940,'proactive content caching strategy with router reassignment in content centric networks based sdn',2,NULL),(7941,'video streaming forwarding in a smart city’s vanet',2,NULL),(7942,'a novel cloudlet-based communication framework for resource-constrained devices',2,NULL),(7943,'on the robot path planning using cloud computing for large grid maps',2,NULL),(7944,'trust intrusion detection system based on location for wireless sensor network',2,NULL),(7945,'ros web services: a tutorial',2,NULL),(7946,'simulated evolution based algorithm versus exact method for virtual private network design',2,NULL),(7947,'a new scalable multicast routing algorithm for interactive real-time applications',2,NULL),(7948,'modeling source authentication protocols in wireless sensor networks using hlpsl',2,NULL),(7949,'applying information retrieval to distributed hash table (dht) systems',2,NULL),(7950,'amlcc: adaptive multi-layer connected chains mechanism for multicast sender authentication of media-streaming',2,NULL),(7951,'autonomic architecture for wireless routing protocols',2,NULL),(7952,'an efficient hybrid recovery mechanism for mpls-based networks',2,NULL),(7953,'evt: evolutionary algorithm for vpn tree provisioning',2,NULL),(7954,'connectivity aware instrumental approach for measuring vocal transmission quality over a wireless ad-hoc network',2,NULL),(7955,'proposition of a cross-layer architecture model for the support of qos in ad-hoc networks',2,NULL),(7956,'new bound-based net criticality metrics for timing-driven physical design',2,NULL),(7957,'timing driven genetic placement',2,NULL),(7958,'razan: a high‐performance switch architecture for atm networks',2,NULL),(7959,'a fast parallel‐tree switch architecture for atm networks',2,NULL),(7960,'cell-based physical design under timing constraints',2,NULL),(7961,'an analytical hierarchy process-based approach to solve the multi-objective multiple traveling salesman problem',1,NULL),(7962,'fpmipv6-s: an enhanced mobility protocol for 6lowpan-based wireless mobile sensor networks',0,NULL),(7963,'rescue‐sink: dynamic sink augmentation for rpl in the internet of things',1,NULL),(7964,'effective distributed trust management model for internet of things',1,NULL),(7965,'performance evaluation of virtual machines migration within a datacenter',1,NULL),(7966,'a synchronized offline cloudlet architecture',1,NULL),(7967,'impact of user emotion and video content on video quality of experience',1,NULL),(7968,'ensuring video qoe using http adaptive streaming: issues and challenges',1,NULL),(7969,'armlcc: adaptive and recovery-based multi-layer connected chain mechanism for multicast source authentication',1,NULL),(7970,'mobility management in wireless sensor networks',1,NULL),(7971,'a new multicast routing algorithm with cost, delay and delay-variation constraints',1,NULL),(7972,'radiale: a framework for benchmarking link quality estimators',1,NULL),(7973,'optimal vpn design: the ilec/clec dilemma',1,NULL),(7974,'an adaptive switching te based on notification subscription within mpls domains',1,NULL),(7975,'a note regarding ″loopy belief propagation ″convergence in probabilistic and possibilistic networks',1,NULL),(7976,'mobility aware playout algorithm for interactive audio streaming over wireless ad-hoc networks',1,NULL),(7977,'design of a priority active queue management',1,NULL),(7978,'iterative computer algorithms with applications in engineering-chapter 2: partitioning',1,NULL),(7979,'fuzzy genetic algorithm for floorplanning engineering intelligent systems for electrical engineering and communications 8 (3): 145-153 sep 2000',1,NULL),(7980,'stochastic evolution algorithm for technology mapping',0,NULL),(7981,'high-level synthesis from purely behavioral descriptions',1,NULL),(7982,'automated vhdl composition from ahpl',1,NULL),(7983,'an edif based system for timing prediction and verification',1,NULL),(7984,'multi-valued processors using solitons',1,NULL),(7985,'simulation analysis and validation of a fuzzy link quality estimator',1,NULL),(7986,'a distributed decision making model for cloudlets network: a fog to cloud computing approach',0,NULL),(7987,'data center resource provisioning using particle swarm optimization and cuckoo search: a performance comparison',0,NULL),(7988,'sdn-based replication management framework for ccn networks',0,NULL),(7989,'improving switch-to-controller assignment with load balancing in multi-controller software defined wan (sd-wan)',0,NULL),(7990,'cloudlet-cloud network communication based on blockchain technology',0,NULL),(7991,'routing optimization in sdn using scalable load prediction',0,NULL),(7992,'link efficiency and quality of experience aware routing protocol to improve video streaming in urban vanets',0,NULL),(7993,'energy consumption of virtual machine migration within varied dcn architectures',0,NULL),(7994,'towards a distributed computation offloading architecture for cloud robotics',0,NULL),(7995,'mvmm: data center scheduler algorithm for virtual machine migration',0,NULL),(7996,'fpmipv6-s: a new network-based mobility management scheme for 6lowpan',0,NULL),(7997,'delay and quality of link aware routing protocol enhancing video streaming in urban vanet',0,NULL),(7998,'link quality and qoe aware predictive vertical handoff mechanism for video streaming in urban vanet',0,NULL),(7999,'effective centralized trust management model for internet of things',0,NULL),(8000,'hybrid af/df based mac protocol over shadowed channels for wireless sensor networks',0,NULL),(8001,'fpmipv6-s: a new mobility management protocol for wireless sensor networks',0,NULL),(8002,'fid: fuzzy based intrusion detection for distributed smart devices',0,NULL),(8003,'a fast bit-level mpls-based source routing scheme in software defined networks: sd-{w, l} an',0,NULL),(8004,'exact approach for the optimal design of virtual private network trees assuming a hose workload',0,NULL),(8005,'peer-to-peer full-text keyword search of the web',0,NULL),(8006,'evaluate the quality of service in the wimax environment using the red-fec mechanism',0,NULL),(8007,'a new bayesian model of qos provisioning in diffserv over mpls networks',0,NULL),(8008,'a bayesian k-nn based scheme for qos provisioning in ip/mpls networks',0,NULL),(8009,'on the use of link quality estimation for improving higher layer protocols and mechanisms',0,NULL),(8010,'characteristics of low-power links',0,NULL),(8011,'performance evaluation of link quality estimators',0,NULL),(8012,'a generic cross-layer architecture for autonomic network management with network wide knowledge',0,NULL),(8013,'a distributed e2e recovery mechanism for mpls networks',0,NULL),(8014,'basic evolutionary approach to the traveling salesman problem.',0,NULL),(8015,'study on measurement of link communication quality in wireless sensor network.',0,NULL),(8016,'a generic autonomic architecture to improve routing in manets',0,NULL),(8017,'autonomic position-based qos routing protocol for mobile wireless networks with a cross-layerarchitecture',0,NULL),(8018,'perceptual quality assessment of packet-based vocal conversations over wireless networks',0,NULL),(8019,'exploiting semantics in structured p2p systems',0,NULL),(8020,'self-organization in wireless networks using the autonomic behavior',0,NULL),(8021,'adaptive clustering based on auto–learning algorithm',0,NULL),(8022,'reeqos: an rsvp-te approach for the end-to-end qos provisioning within mpls domains',0,NULL),(8023,'mlcc: multi-layers connected chains scheme for multicast source authentication',0,NULL),(8024,'a protocol for local view data dissemination for a structured cross-layer management to improve qos in ad hoc networks',0,NULL),(8025,'performance analysis of wireless link quality in wireless sensor network.',0,NULL),(8026,'a fuzzy evolutionary algorithm for topology design of...',0,NULL),(8027,'introduction to vlsi physical design',0,NULL),(8028,'partial-flooding multicast routing protocol for ad hoc wireless networks',0,NULL),(8029,'iterative heuristics for multiobjective vlsi cell placement',0,NULL),(8030,'tr o1-o18',0,NULL),(8031,'reducing cell loss in banyan based atm switching fabrics',0,NULL),(8032,'fuzzy evolutionary algorithm for vlsi placement,(spector, l., e. goodman, a. wu, wb langdon, h.-m. voigt, m. gen, s. sen, m. dorigo, s. pezeshk, m. garzon, and e. burke, editors).',0,NULL),(8033,'modern iterative algorithms and thier applications in computer engineering',0,NULL),(8034,'iterative heuristics for timing & low power vlsi standard cell placement',0,NULL),(8035,'theme issue on optimization theory and applications-foreword',0,NULL),(8036,'evolutionary algorithms, simulated annealing, and tabu search: a comparative study [3455-10]',0,NULL),(8037,'timing driven genetic algorithm for placement',0,NULL),(8038,'rtl structural synthesis from behavioral descriptions in a unix environment',0,NULL),(8039,'fuzzy evolutionary hybrid metaheuristic for network topology design lecture notes in computer science 1993: 400-415 2001',0,NULL),(8040,'timing aspects of cell-based asic design',0,NULL),(8041,'a predictive approach to timing driven vlsi system design',0,NULL),(8042,'authors pages',0,NULL),(8043,'honorary chair',0,NULL),(8044,'réglage optimal du buffer de lecture pour un streaming sans rupture à travers un réseau mobile',0,NULL),(8045,'fuzzy approach to extract pertinent information from web resources',0,NULL),(8046,'parallel models for iterative algorithms in a cluster computing environment',0,NULL),(8047,'ieee computer society press',0,NULL),(8048,'schedule–paper presentation',0,NULL),(8049,'la sécurité dans les réseaux de capteurs sans fils',0,NULL),(8050,'sadiqyoussefjakhan, aimane) gccsekfupm. edu. sa',0,NULL),(8051,'multicast tree generation using tabu search',0,NULL),(8052,'single rate multicast congestion control protocols: a performance comparison',0,NULL),(8053,'evaluation of pipelined dilated switch architectures for atm networks',0,NULL),(8054,'review of some uncertain reasoning methods',0,NULL),(8055,'rosaly alday and ruel pagayon performance evaluation of three gpsr-based routing protocols in a military setting...... 32 yasser alroqi, stylianos papanastasiou and evtim …',0,NULL),(8056,'algorithmes de mise à jour dynamique de l ‘arbre de routage: dart',0,NULL),(8057,'computer network',0,NULL),(8058,'e-business simulation: toning technical and strategic requirements to generate business value',0,NULL),(8059,'a comprehensive introduction to vlsi—designed expressly for progressive¡ earning..',0,NULL),(8060,'synchronous/asynchronous transmission',0,NULL),(8061,'an evolutionary algorithm for multicast tree design',0,NULL),(8062,'electrical and computer engineering 5460/6460 vlsi design automation',0,NULL),(8063,'tcp/ip',0,NULL),(8064,'full papers program',0,NULL),(8065,'e-mail: youssef sadiq, hussain) occse. kfupm. edu. sa',0,NULL),(8066,'the ieee symposium on computers and communications iscc 2010',0,NULL),(8067,'data analysis and outlier detection in smart city wireless sensor networks',0,NULL),(8068,'structured backbone design of cns',0,NULL),(8069,'the future of electrical and computer engineering education',100,NULL),(8070,'calibrated peer review and assessing learning outcomes',63,NULL),(8071,'laser positioning system for earth boring apparatus',47,NULL),(8072,'survey of harmonic levels on the southwestern electric power company system',41,NULL),(8073,'industrial sponsored design projects addressed by student design teams',40,NULL),(8074,'using computer-mediated peer review in an engineering design course',29,NULL),(8075,'improving student intuition via rensselaer\'s new mobile studio pedagogy',25,NULL),(8076,'incorporating student peer-review into an introduction to engineering design course',22,NULL),(8077,'introduction to wireless systems',1,NULL),(8078,'using the mobile studio to facilitate non-traditional approaches to education and outreach',15,NULL),(8079,'multi-institutional development of mobile studio based education and outreach',13,NULL),(8080,'harmonic response tests on distribution circuit potential transformers',12,NULL),(8081,'calibrated peer review: a tool for assessing the process as well as the product in learning outcomes',9,NULL),(8082,'an undergraduate parallel processing laboratory',8,NULL),(8083,'parallel load-flow algorithm using a decomposition method for space-based power systems',8,NULL),(8084,'asynchronous learning environment for integrating technical communication into engineering courses',7,NULL),(8085,'a web based tool for implementing peer review',4,NULL),(8086,'express a tool for teaching parallel processing',4,NULL),(8087,'assessing engineering design experiences using calibrated peer review',0,NULL),(8088,'an undergraduate, entrepreneurial design sequence: a decade of development and success',0,NULL),(8089,'calibrated peer review for abet assessment',0,NULL),(8090,'using catme to document and improve the effectiveness of teamwork in capstone courses',2,NULL),(8091,'international capstone student projects giving real world, global team experiences',2,NULL),(8092,'initial survey of engineering technology capstone courses and teamwork building using catme',2,NULL),(8093,'cpr: a tool for addressing ec2000, item g--ability to communicate effectively',2,NULL),(8094,'assessing the outcomes of e-teams for engineers. beyond boundaries',2,NULL),(8095,'a technique for load flow analysis on a power system',2,NULL),(8096,'mathematical modeling of the dc-ac inverters for the space shuttle',2,NULL),(8097,'use of catme peer review measurement tool to assess team work skills',1,NULL),(8098,'practical interpretation of student evaluations for starting professors',1,NULL),(8099,'calibrated peer review (cpr): a tool for integrating meaningful writing assignments into technical courses',1,NULL),(8100,'using calibrated peer review™ to mediate writing and to assess instructional outcomes',1,NULL),(8101,'analysis of multiprocessor architectures for management of space-based power systems',1,NULL),(8102,'adepts: space-based power system management using parallel architecture',1,NULL),(8103,'steady state mathematical model for the dc-ac inverters on the space shuttle',1,NULL),(8104,'forming more effective teams using catme teammaker and the gale-shapley algorithm',0,NULL),(8105,'engineering technology students: do they approach capstone courses differently than other students?',0,NULL),(8106,'remote circuit locking switch system',0,NULL),(8107,'ac 2011-2039: multi-institutional development of mobile studio based education and outreach',0,NULL),(8108,'2008 index ieee transactions on professional communication vol. 51',0,NULL),(8109,'work in progress-graduate exchange program in microelectronics system engineering',0,NULL),(8110,'ac 2008-1087: design for visual and hearing impaired using a social entrepreneurship model',0,NULL),(8111,'ac 2008-2059: using writing to assess learning in engineering design: quantitative approaches',0,NULL),(8112,'abet assessment using calibrated peer review',0,NULL),(8113,'ac 2007-2484: a web-based tool for implementing peer review',0,NULL),(8114,'ac 2007-1753: an undergraduate, entrepreneurial design sequence: a decade of development and success',0,NULL),(8115,'evaluating calibrated peer review™: implementation at rose-hulman institute of technology',0,NULL),(8116,'building an entrepreneurial venture',0,NULL),(8117,'commercialization concepts and engineering design',0,NULL),(8118,'developing and utilizing interactive materials and technologies for wireless engineering education through meaningful collaboration',0,NULL),(8119,'explore engineering: rose-hulman’s outreach to middle and high school students',0,NULL),(8120,'parallel processing at rose-hulman institute of technology',0,NULL),(8121,'modeling of dc spacecraft power systems',0,NULL),(8122,'modeling of dc spacecraft power systems(final report)',0,NULL),(8123,'classification of load sites by their harmonic content',0,NULL),(8124,'parallel processing methods for space based power systems',0,NULL),(8125,'top-down method of teaching computer programming',0,NULL),(8126,'design for a small-scale distributred microcomputer control system',0,NULL),(8127,'power system state estimation for a spacecraft power system',0,NULL),(8128,'development of parallel algorithms for electrical power management in space applications',0,NULL),(8129,'numerical and discrete fourier analysis of solar radiation and climate data for lake charles, louisiana.',0,NULL),(8130,'for the space shuttle, _!',0,NULL),(8131,'mathematical model for the dc-ac inverter for the space shuttle',0,NULL),(8132,'design of a digital state variable interface between a dc servo motor and a z-80 microprocessor',0,NULL),(8133,'decomposition-coordination technique to perform',0,NULL),(8134,'device physics of dye solar cells',422,NULL),(8135,'review of stability for advanced dye solar cells',237,NULL),(8136,'review of materials and manufacturing options for large area flexible dye solar cells',174,NULL),(8137,'spectral characteristics of light harvesting, electron injection, and steady-state charge collection in pressed tio2 dye solar cells',169,NULL),(8138,'dye-sensitized nanostructured and organic photovoltaic cells: technical review and preliminary tests',132,NULL),(8139,'spray deposition and compression of tio2 nanoparticle films for dye-sensitized solar cells on plastic substrates',121,NULL),(8140,'nanostructured dye solar cells on flexible substrates',119,NULL),(8141,'scalability and feasibility of photoelectrochemical h 2 evolution: the ultimate limit of pt nanoparticle as an her catalyst',116,NULL),(8142,'prod reference manual',112,NULL),(8143,'charge transfer resistance of spray deposited and compressed counter electrodes for dye-sensitized nanoparticle solar cells on plastic substrates',86,NULL),(8144,'initial performance of dye solar cells on stainless steel substrates',76,NULL),(8145,'dye solar cells on ito-pet substrate with tio2 recombination blocking layers',64,NULL),(8146,'effect of diffuse light scattering designs on the efficiency of dye solar cells: an integral optical and electrical description',57,NULL),(8147,'high performance dye-sensitized solar cells with inkjet printed ionic liquid electrolyte',55,NULL),(8148,'single-walled carbon nanotube thin-film counter electrodes for indium tin oxide-free plastic dye solar cells',51,NULL),(8149,'regenerative effects by temperature variations in dye-sensitized solar cells',51,NULL),(8150,'linking optical and electrical small amplitude perturbation techniques for dynamic performance characterization of dye solar cells',47,NULL),(8151,'stability of dye solar cells with photoelectrode on metal substrates',47,NULL),(8152,'dye-sensitized solar cells with inkjet-printed dyes',46,NULL),(8153,'metallic and plastic dye solar cells',46,NULL),(8154,'in situ image processing method to investigate performance and stability of dye solar cells',45,NULL),(8155,'a durable swcnt/pet polymer foil based metal free counter electrode for flexible dye-sensitized solar cells',42,NULL),(8156,'charge transport and photocurrent generation characteristics in dye solar cells containing thermally degraded n719 dye molecules',42,NULL),(8157,'effect of electrolyte bleaching on the stability and performance of dye solar cells',39,NULL),(8158,'effect of nonuniform generation and inefficient collection of electrons on the dynamic photocurrent and photovoltage response of nanostructured photoelectrodes',38,NULL),(8159,'nanocellulose aerogel membranes for optimal electrolyte filling in dye solar cells',36,NULL),(8160,'two-dimensional time-dependent numerical modeling of edge effects in dye solar cells',35,NULL),(8161,'dye sensitized solar cells as optically random photovoltaic media',0,NULL),(8162,'stabilization of metal counter electrodes for dye solar cells',32,NULL),(8163,'comparison of dye solar cell counter electrodes based on different carbon nanostructures',28,NULL),(8164,'flexible metal-free counter electrode for dye solar cells based on conductive polymer and carbon nanotubes',25,NULL),(8165,'spatial distribution and decrease of dye solar cell performance induced by electrolyte filling',24,NULL),(8166,'highly conductive, non-permeable, fiber based substrate for counter electrode application in dye-sensitized solar cells',23,NULL),(8167,'do counter electrodes on metal substrates work with cobalt complex based electrolyte in dye sensitized solar cells?',23,NULL),(8168,'segmented cell design for improved factoring of aging effects in dye solar cells',23,NULL),(8169,'highly catalytic carbon nanotube counter electrode on plastic for dye solar cells utilizing cobalt-based redox mediator',22,NULL),(8170,'investigation of temperature and aging effects in nanostructured dye solar cells studied by electrochemical impedance spectroscopy',22,NULL),(8171,'the effect of electrolyte purification on the performance and long-term stability of dye-sensitized solar cells',21,NULL),(8172,'effect of molecular filtering and electrolyte composition on the spatial variation in performance of dye solar cells',21,NULL),(8173,'a single‐walled carbon nanotube coated flexible pvc counter electrode for dye‐sensitized solar cells',19,NULL),(8174,'high performance low temperature carbon composite catalysts for flexible dye sensitized solar cells',19,NULL),(8175,'thin film nano solar cells—from device optimization to upscaling',18,NULL),(8176,'moisture sensor at glass/polymer interface for monitoring of photovoltaic module encapsulants',18,NULL),(8177,'physical modeling of photoelectrochemical hydrogen production devices',16,NULL),(8178,'critical analysis on the quality of stability studies of perovskite and dye solar cells',15,NULL),(8179,'intriguing photochemistry of the additives in the dye-sensitized solar cells',13,NULL),(8180,'comparison of plastic based counter electrodes for dye sensitized solar cells',13,NULL),(8181,'fully stable numerical calculations for finite one-dimensional structures: mapping the transfer matrix method',12,NULL),(8182,'inkjet-printed platinum counter electrodes for dye-sensitized solar cells',11,NULL),(8183,'comparative analysis of ceramic-carbonate nanocomposite fuel cells using composite gdc/nlc electrolyte with different perovskite structured cathode materials',10,NULL),(8184,'theoretical efficiency limits of ideal coloured opaque photovoltaics',8,NULL),(8185,'carbon nanotube film replacing silver in high-efficiency solid-state dye solar cells employing polymer hole conductor',8,NULL),(8186,'analysis of dye degradation products and assessment of the dye purity in dye‐sensitized solar cells',7,NULL),(8187,'low cost ferritic stainless steel in dye sensitized solar cells with cobalt complex electrolyte',7,NULL),(8188,'application of dye-sensitized and perovskite solar cells on flexible substrates',6,NULL),(8189,'on the mass transport in apparently iodine-free ionic liquid polyaniline-coated carbon black composite electrolytes in dye-sensitized solar cells',6,NULL),(8190,'insights into corrosion in dye solar cells',5,NULL),(8191,'symmetry analysis of the numerical instabilities in the transfer matrix method',5,NULL),(8192,'an analytical model of hydrogen evolution and oxidation reactions on electrodes partially covered with a catalyst',4,NULL),(8193,'multiscale in modelling and validation for solar photovoltaics',2,NULL),(8194,'two-phase model of hydrogen transport to optimize nanoparticle catalyst loading for hydrogen evolution reaction',2,NULL),(8195,'performance limiting factors in flexible dye solar cells',2,NULL),(8196,'minimizing structural deformation of gold nanorods in plasmon-enhanced dye-sensitized solar cells',1,NULL),(8197,'process steps towards a flexible dye solar cell module',1,NULL),(8198,'the performance enhanced by back reflection in nanostructured dye-sensitized solar cells',0,NULL),(8199,'polymeeripolttokennon jännitehäviöiden mittaaminen',1,NULL),(8200,'thin nanostructured solar cells on metal sheets',1,NULL),(8201,'large area optimized thin film nano solar cells on metal sheets',1,NULL),(8202,'accelerated aging test for carbon composite counter electrodes based dye sensitized solar cells',1,NULL),(8203,'nir-absorbing transition metal complexes with redox-active ligands',0,NULL),(8204,'perovskite solar cell ageing standards need reproducible data on failure mechanisms',0,NULL),(8205,'angular optical behavior of photonic-crystal-based dye-sensitized solar cells',0,NULL),(8206,'can platinum scale for pec hydrogen evolution at the terawatt level?',0,NULL),(8207,'nordic dsc',0,NULL),(8208,'analysis of degradation issues for improved dye sensitized solar cells',0,NULL),(8209,'the influnce of stainless steel substrate and thinkness of nano-tio_2 film on dye-sensitizied solar cells',0,NULL),(8210,'nanostructured solar cells on plastic',0,NULL);
/*!40000 ALTER TABLE `articles` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `articlesperuser`
--

DROP TABLE IF EXISTS `articlesperuser`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `articlesperuser` (
  `articleId` int NOT NULL,
  `cibitId` varchar(45) NOT NULL,
  KEY `FK_USERS_ARITCLES_idx` (`cibitId`),
  KEY `FK_ARTICLES_ARTICLESPERUSER_idx` (`articleId`),
  CONSTRAINT `FK_ARTICLES_ARTICLESPERUSER` FOREIGN KEY (`articleId`) REFERENCES `articles` (`articleId`) ON DELETE CASCADE,
  CONSTRAINT `FK_USERS_ARITCLESPERUSER` FOREIGN KEY (`cibitId`) REFERENCES `users` (`cibitId`) ON DELETE CASCADE ON UPDATE RESTRICT
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `articlesperuser`
--

LOCK TABLES `articlesperuser` WRITE;
/*!40000 ALTER TABLE `articlesperuser` DISABLE KEYS */;
INSERT INTO `articlesperuser` VALUES (7361,'1'),(7362,'1'),(7363,'1'),(7364,'1'),(7365,'1'),(7366,'1'),(7367,'1'),(7368,'1'),(7369,'1'),(7370,'1'),(7371,'1'),(7372,'1'),(7373,'1'),(7374,'1'),(7375,'1'),(7376,'1'),(7377,'1'),(7378,'1'),(7379,'1'),(7380,'1'),(7381,'1'),(7382,'1'),(7383,'1'),(7384,'1'),(7385,'1'),(7386,'1'),(7387,'1'),(7388,'1'),(7389,'1'),(7390,'1'),(7391,'1'),(7392,'1'),(7393,'1'),(7394,'1'),(7395,'1'),(7396,'1'),(7397,'1'),(7398,'1'),(7399,'1'),(7400,'1'),(7401,'1'),(7402,'1'),(7403,'1'),(7404,'1'),(7405,'1'),(7406,'1'),(7407,'1'),(7408,'1'),(7409,'1'),(7410,'1'),(7411,'1'),(7412,'1'),(7413,'1'),(7414,'1'),(7415,'1'),(7416,'1'),(7417,'1'),(7418,'1'),(7419,'1'),(7420,'1'),(7421,'1'),(7422,'1'),(7423,'1'),(7424,'1'),(7425,'1'),(7426,'1'),(7427,'1'),(7428,'1'),(7429,'1'),(7430,'1'),(7431,'1'),(7432,'1'),(7433,'1'),(7434,'1'),(7435,'1'),(7436,'1'),(7437,'1'),(7438,'1'),(7439,'1'),(7440,'1'),(7441,'1'),(7442,'1'),(7443,'1'),(7444,'1'),(7445,'1'),(7446,'1'),(7447,'1'),(7448,'1'),(7449,'1'),(7450,'1'),(7451,'1'),(7452,'1'),(7453,'1'),(7454,'1'),(7455,'1'),(7456,'1'),(7457,'1'),(7458,'1'),(7459,'1'),(7460,'1'),(7461,'1'),(7462,'1'),(7463,'1'),(7464,'1'),(7465,'1'),(7466,'1'),(7467,'1'),(7468,'1'),(7469,'1'),(7470,'1'),(7471,'1'),(7472,'1'),(7473,'1'),(7474,'1'),(7475,'1'),(7476,'1'),(7477,'1'),(7478,'1'),(7479,'1'),(7480,'1'),(7481,'1'),(7482,'1'),(7483,'1'),(7484,'1'),(7485,'1'),(7486,'1'),(7487,'1'),(7488,'1'),(7489,'1'),(7490,'1'),(7491,'1'),(7492,'1'),(7493,'1'),(7494,'1'),(7495,'1'),(7496,'1'),(7497,'1'),(7498,'1'),(7499,'1'),(7500,'1'),(7501,'1'),(7502,'1'),(7503,'1'),(7504,'1'),(7505,'1'),(7506,'1'),(7507,'1'),(7508,'1'),(7509,'1'),(7510,'1'),(7511,'1'),(7512,'1'),(7513,'1'),(7514,'1'),(7515,'1fCVOhQ'),(7516,'1fCVOhQ'),(7517,'1fCVOhQ'),(7518,'1fCVOhQ'),(7519,'1fCVOhQ'),(7520,'1fCVOhQ'),(7521,'1fCVOhQ'),(7522,'1fCVOhQ'),(7523,'1fCVOhQ'),(7524,'1fCVOhQ'),(7525,'1fCVOhQ'),(7526,'1fCVOhQ'),(7527,'1fCVOhQ'),(7528,'1fCVOhQ'),(7529,'1fCVOhQ'),(7530,'1fCVOhQ'),(7531,'2'),(7532,'2'),(7533,'2'),(7534,'2'),(7535,'2'),(7536,'2'),(7537,'2'),(7538,'2'),(7539,'2'),(7540,'2'),(7541,'2'),(7542,'2'),(7543,'2'),(7544,'2'),(7545,'2'),(7546,'2'),(7547,'2'),(7548,'2'),(7549,'2'),(7550,'2'),(7551,'2'),(7552,'2'),(7553,'2'),(7554,'2'),(7555,'2'),(7556,'2'),(7557,'2'),(7558,'2'),(7559,'2'),(7560,'2'),(7561,'2'),(7562,'2'),(7563,'2'),(7564,'2'),(7565,'2'),(7566,'2'),(7567,'2'),(7568,'2'),(7569,'2'),(7570,'2'),(7571,'2'),(7572,'2'),(7573,'2'),(7574,'2'),(7575,'2'),(7576,'2'),(7577,'2'),(7578,'2'),(7579,'2'),(7580,'2'),(7581,'2'),(7582,'2'),(7583,'2'),(7584,'2'),(7585,'2'),(7586,'2'),(7587,'2'),(7588,'2'),(7589,'2'),(7590,'2'),(7591,'2'),(7592,'2'),(7593,'2'),(7594,'2'),(7595,'2'),(7596,'2'),(7597,'2'),(7598,'2'),(7599,'2'),(7600,'2'),(7601,'2'),(7602,'2'),(7603,'2'),(7604,'2'),(7605,'2'),(7606,'2'),(7607,'2'),(7608,'2'),(7609,'2'),(7610,'2'),(7611,'2'),(7612,'2'),(7613,'2'),(7614,'2'),(7615,'2'),(7616,'2'),(7617,'2'),(7618,'2'),(7619,'2'),(7620,'2'),(7621,'2'),(7622,'2'),(7623,'2'),(7624,'2'),(7625,'2'),(7626,'2'),(7627,'2'),(7628,'2'),(7629,'2'),(7630,'2'),(7631,'2'),(7632,'2'),(7633,'2'),(7634,'2'),(7635,'2'),(7636,'2'),(7637,'2'),(7638,'2'),(7639,'2'),(7640,'2'),(7641,'2'),(7642,'2'),(7643,'2'),(7644,'2'),(7645,'2'),(7646,'2'),(7647,'2'),(7648,'2'),(7649,'2'),(7650,'2'),(7651,'2'),(7652,'2'),(7653,'2'),(7654,'2'),(7655,'2'),(7656,'2'),(7657,'2'),(7658,'2'),(7659,'2'),(7660,'2'),(7661,'2'),(7662,'2'),(7663,'2'),(7664,'2'),(7665,'2'),(7666,'2'),(7667,'2'),(7668,'2'),(7669,'2'),(7670,'2'),(7671,'2'),(7672,'2'),(7673,'2'),(7674,'2'),(7675,'2'),(7676,'2'),(7677,'2'),(7678,'2'),(7679,'2'),(7680,'2'),(7681,'2'),(7682,'2'),(7683,'2'),(7684,'2'),(7685,'2'),(7686,'2'),(7687,'2'),(7688,'2'),(7689,'2'),(7690,'2'),(7691,'2'),(7692,'2'),(7693,'2'),(7694,'2'),(7695,'2'),(7696,'2'),(7697,'2'),(7698,'2'),(7699,'2'),(7700,'2'),(7701,'2'),(7702,'2'),(7703,'2'),(7704,'2'),(7705,'2'),(7706,'2'),(7707,'2'),(7708,'2'),(7709,'2'),(7710,'2'),(7711,'2'),(7712,'2'),(7713,'2'),(7714,'2'),(7715,'2'),(7716,'2'),(7717,'2'),(7718,'2'),(7719,'2'),(7720,'2'),(7721,'2'),(7722,'2'),(7723,'2'),(7724,'2'),(7725,'2'),(7726,'2'),(7727,'2'),(7728,'2'),(7729,'2'),(7730,'2'),(7731,'2'),(7732,'2'),(7733,'2'),(7734,'2'),(7735,'2'),(7736,'2'),(7737,'2'),(7738,'2'),(7739,'2'),(7740,'2'),(7741,'2'),(7742,'2'),(7743,'2'),(7744,'2'),(7745,'2'),(7746,'2'),(7747,'2'),(7748,'2'),(7749,'2'),(7750,'2'),(7751,'2'),(7752,'2'),(7753,'2'),(7754,'2'),(7755,'2'),(7756,'2'),(7757,'2'),(7758,'2'),(7759,'2'),(7760,'2'),(7761,'2'),(7762,'2'),(7763,'2'),(7764,'2'),(7765,'2'),(7766,'2'),(7767,'2'),(7768,'2'),(7769,'2'),(7770,'2'),(7771,'2'),(7772,'2'),(7773,'2'),(7774,'2'),(7775,'2'),(7776,'2'),(7777,'2'),(7778,'2'),(7779,'2'),(7780,'2'),(7781,'2'),(7782,'2'),(7783,'2'),(7784,'2'),(7785,'2'),(7786,'2'),(7787,'2'),(7788,'2'),(7789,'2'),(7790,'2'),(7791,'2'),(7792,'2'),(7793,'2'),(7794,'2'),(7795,'2'),(7796,'3'),(7797,'3'),(7798,'3'),(7799,'3'),(7800,'3'),(7801,'3'),(7802,'3'),(7803,'3'),(7804,'3'),(7805,'3'),(7806,'3'),(7807,'3'),(7808,'3'),(7809,'3'),(7810,'3'),(7811,'3'),(7812,'3'),(7813,'3'),(7814,'3'),(7815,'3'),(7816,'3'),(7817,'3'),(7818,'3'),(7819,'3'),(7820,'3'),(7821,'3'),(7822,'3'),(7823,'3'),(7824,'3'),(7825,'3'),(7826,'3'),(7827,'3'),(7828,'3'),(7829,'3'),(7830,'3'),(7831,'3'),(7832,'3'),(7833,'3'),(7834,'3'),(7835,'3'),(7836,'3'),(7837,'3'),(7838,'3'),(7839,'3'),(7840,'3'),(7841,'3'),(7842,'3'),(7843,'3'),(7844,'3'),(7845,'3'),(7846,'3'),(7847,'3'),(7848,'3'),(7849,'3'),(7850,'3'),(7851,'3'),(7852,'3'),(7853,'3'),(7854,'3'),(7855,'3'),(7856,'3'),(7857,'3'),(7858,'3'),(7859,'3'),(7860,'3'),(7861,'3'),(7862,'3'),(7863,'3'),(7864,'3'),(7865,'3'),(7866,'3'),(7867,'3'),(7868,'3'),(7869,'3'),(7870,'3'),(7871,'3'),(7872,'3'),(7873,'3'),(7874,'3'),(7875,'3'),(7876,'3'),(7877,'3'),(7878,'3'),(7879,'3'),(7880,'3'),(7881,'3'),(7882,'3'),(7883,'3'),(7884,'3'),(7885,'3'),(7886,'3'),(7887,'3'),(7888,'3'),(7889,'3'),(7890,'3'),(7891,'3'),(7892,'3'),(7893,'3'),(7894,'3'),(7895,'3'),(7896,'3'),(7897,'3'),(7898,'3'),(7899,'3'),(7900,'3'),(7901,'3'),(7902,'3'),(7903,'3'),(7904,'3'),(7905,'3'),(7906,'3'),(7907,'3'),(7908,'3'),(7909,'3'),(7910,'3'),(7911,'3'),(7912,'3'),(7913,'3'),(7914,'3'),(7915,'3'),(7916,'3'),(7917,'3'),(7918,'3'),(7919,'3'),(7920,'3'),(7921,'3'),(7922,'3'),(7923,'3'),(7924,'3'),(7925,'3'),(7926,'3'),(7927,'3'),(7928,'3'),(7929,'3'),(7930,'3'),(7931,'3'),(7932,'3'),(7933,'3'),(7934,'3'),(7935,'3'),(7936,'3'),(7937,'3'),(7938,'3'),(7939,'3'),(7940,'3'),(7941,'3'),(7942,'3'),(7943,'3'),(7944,'3'),(7945,'3'),(7946,'3'),(7947,'3'),(7948,'3'),(7949,'3'),(7950,'3'),(7951,'3'),(7952,'3'),(7953,'3'),(7954,'3'),(7955,'3'),(7956,'3'),(7957,'3'),(7958,'3'),(7959,'3'),(7960,'3'),(7961,'3'),(7962,'3'),(7963,'3'),(7964,'3'),(7965,'3'),(7966,'3'),(7967,'3'),(7968,'3'),(7969,'3'),(7970,'3'),(7971,'3'),(7972,'3'),(7973,'3'),(7974,'3'),(7975,'3'),(7976,'3'),(7977,'3'),(7978,'3'),(7979,'3'),(7980,'3'),(7981,'3'),(7982,'3'),(7983,'3'),(7984,'3'),(7985,'3'),(7986,'3'),(7987,'3'),(7988,'3'),(7989,'3'),(7990,'3'),(7991,'3'),(7992,'3'),(7993,'3'),(7994,'3'),(7995,'3'),(7996,'3'),(7997,'3'),(7998,'3'),(7999,'3'),(8000,'3'),(8001,'3'),(8002,'3'),(8003,'3'),(8004,'3'),(8005,'3'),(8006,'3'),(8007,'3'),(8008,'3'),(8009,'3'),(8010,'3'),(8011,'3'),(8012,'3'),(8013,'3'),(8014,'3'),(8015,'3'),(8016,'3'),(8017,'3'),(8018,'3'),(8019,'3'),(8020,'3'),(8021,'3'),(8022,'3'),(8023,'3'),(8024,'3'),(8025,'3'),(8026,'3'),(8027,'3'),(8028,'3'),(8029,'3'),(8030,'3'),(8031,'3'),(8032,'3'),(8033,'3'),(8034,'3'),(8035,'3'),(8036,'3'),(8037,'3'),(8038,'3'),(8039,'3'),(8040,'3'),(8041,'3'),(8042,'3'),(8043,'3'),(8044,'3'),(8045,'3'),(8046,'3'),(8047,'3'),(8048,'3'),(8049,'3'),(8050,'3'),(8051,'3'),(8052,'3'),(8053,'3'),(8054,'3'),(8055,'3'),(8056,'3'),(8057,'3'),(8058,'3'),(8059,'3'),(8060,'3'),(8061,'3'),(8062,'3'),(8063,'3'),(8064,'3'),(8065,'3'),(8066,'3'),(8067,'3'),(8068,'3'),(8069,'4'),(8070,'4'),(8071,'4'),(8072,'4'),(8073,'4'),(8074,'4'),(8075,'4'),(8076,'4'),(8077,'4'),(8078,'4'),(8079,'4'),(8080,'4'),(8081,'4'),(8082,'4'),(8083,'4'),(8084,'4'),(8085,'4'),(8086,'4'),(8087,'4'),(8088,'4'),(8089,'4'),(8090,'4'),(8091,'4'),(8092,'4'),(8093,'4'),(8094,'4'),(8095,'4'),(8096,'4'),(8097,'4'),(8098,'4'),(8099,'4'),(8100,'4'),(8101,'4'),(8102,'4'),(8103,'4'),(8104,'4'),(8105,'4'),(8106,'4'),(8107,'4'),(8108,'4'),(8109,'4'),(8110,'4'),(8111,'4'),(8112,'4'),(8113,'4'),(8114,'4'),(8115,'4'),(8116,'4'),(8117,'4'),(8118,'4'),(8119,'4'),(8120,'4'),(8121,'4'),(8122,'4'),(8123,'4'),(8124,'4'),(8125,'4'),(8126,'4'),(8127,'4'),(8128,'4'),(8129,'4'),(8130,'4'),(8131,'4'),(8132,'4'),(8133,'4'),(8134,'Shalom1'),(8135,'Shalom1'),(8136,'Shalom1'),(8137,'Shalom1'),(8138,'Shalom1'),(8139,'Shalom1'),(8140,'Shalom1'),(8141,'Shalom1'),(8142,'Shalom1'),(8143,'Shalom1'),(8144,'Shalom1'),(8145,'Shalom1'),(8146,'Shalom1'),(8147,'Shalom1'),(8148,'Shalom1'),(8149,'Shalom1'),(8150,'Shalom1'),(8151,'Shalom1'),(8152,'Shalom1'),(8153,'Shalom1'),(8154,'Shalom1'),(8155,'Shalom1'),(8156,'Shalom1'),(8157,'Shalom1'),(8158,'Shalom1'),(8159,'Shalom1'),(8160,'Shalom1'),(8161,'Shalom1'),(8162,'Shalom1'),(8163,'Shalom1'),(8164,'Shalom1'),(8165,'Shalom1'),(8166,'Shalom1'),(8167,'Shalom1'),(8168,'Shalom1'),(8169,'Shalom1'),(8170,'Shalom1'),(8171,'Shalom1'),(8172,'Shalom1'),(8173,'Shalom1'),(8174,'Shalom1'),(8175,'Shalom1'),(8176,'Shalom1'),(8177,'Shalom1'),(8178,'Shalom1'),(8179,'Shalom1'),(8180,'Shalom1'),(8181,'Shalom1'),(8182,'Shalom1'),(8183,'Shalom1'),(8184,'Shalom1'),(8185,'Shalom1'),(8186,'Shalom1'),(8187,'Shalom1'),(8188,'Shalom1'),(8189,'Shalom1'),(8190,'Shalom1'),(8191,'Shalom1'),(8192,'Shalom1'),(8193,'Shalom1'),(8194,'Shalom1'),(8195,'Shalom1'),(8196,'Shalom1'),(8197,'Shalom1'),(8198,'Shalom1'),(8199,'Shalom1'),(8200,'Shalom1'),(8201,'Shalom1'),(8202,'Shalom1'),(8203,'Shalom1'),(8204,'Shalom1'),(8205,'Shalom1'),(8206,'Shalom1'),(8207,'Shalom1'),(8208,'Shalom1'),(8209,'Shalom1'),(8210,'Shalom1');
/*!40000 ALTER TABLE `articlesperuser` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `block`
--

DROP TABLE IF EXISTS `block`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `block` (
  `blockId` int NOT NULL DEFAULT '0',
  `timStamp` datetime NOT NULL,
  `proof` varchar(256) NOT NULL DEFAULT '100',
  `previousHash` varchar(256) NOT NULL,
  PRIMARY KEY (`blockId`),
  UNIQUE KEY `blockId_UNIQUE` (`blockId`),
  UNIQUE KEY `previousHash_UNIQUE` (`previousHash`),
  UNIQUE KEY `proof_UNIQUE` (`proof`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `block`
--

LOCK TABLES `block` WRITE;
/*!40000 ALTER TABLE `block` DISABLE KEYS */;
/*!40000 ALTER TABLE `block` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `coins`
--

DROP TABLE IF EXISTS `coins`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `coins` (
  `coinId` varchar(45) NOT NULL,
  `cibitId` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`coinId`),
  UNIQUE KEY `coinId_UNIQUE` (`coinId`),
  KEY `cibitId_idx` (`cibitId`),
  CONSTRAINT `FK_USERS_COINS` FOREIGN KEY (`cibitId`) REFERENCES `users` (`cibitId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `coins`
--

LOCK TABLES `coins` WRITE;
/*!40000 ALTER TABLE `coins` DISABLE KEYS */;
/*!40000 ALTER TABLE `coins` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `coinspertranscation`
--

DROP TABLE IF EXISTS `coinspertranscation`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `coinspertranscation` (
  `transactionsId` int NOT NULL,
  `newCoinId` varchar(40) NOT NULL,
  `oldcoinId` varchar(45) NOT NULL,
  `status` int NOT NULL,
  UNIQUE KEY `CoinsNumber_UNIQUE` (`newCoinId`),
  UNIQUE KEY `coinId_UNIQUE` (`oldcoinId`),
  KEY `FK_TRANSACTIONS_COINSPERTRANSACTION_idx` (`transactionsId`),
  KEY `FK_STATUSTYPE_COINSPERTRANSACTION_idx` (`status`),
  CONSTRAINT `FK_COINS_COINSPERTRANSACTION` FOREIGN KEY (`oldcoinId`) REFERENCES `coins` (`coinId`),
  CONSTRAINT `FK_STATUSTYPE_COINSPERTRANSACTION` FOREIGN KEY (`status`) REFERENCES `statustype` (`id`),
  CONSTRAINT `FK_TRANSACTIONS_COINSPERTRANSACTION` FOREIGN KEY (`transactionsId`) REFERENCES `transactions` (`transatcionId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `coinspertranscation`
--

LOCK TABLES `coinspertranscation` WRITE;
/*!40000 ALTER TABLE `coinspertranscation` DISABLE KEYS */;
/*!40000 ALTER TABLE `coinspertranscation` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `researches`
--

DROP TABLE IF EXISTS `researches`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `researches` (
  `researchId` int NOT NULL AUTO_INCREMENT,
  `researchName` varchar(45) NOT NULL,
  `status` int NOT NULL,
  PRIMARY KEY (`researchId`),
  UNIQUE KEY `researchId_UNIQUE` (`researchId`),
  KEY `FK_RESEARCHES_STATUSTYPE_idx` (`status`),
  CONSTRAINT `FK_RESEARCHES_STATUSTYPE` FOREIGN KEY (`status`) REFERENCES `statustype` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `researches`
--

LOCK TABLES `researches` WRITE;
/*!40000 ALTER TABLE `researches` DISABLE KEYS */;
/*!40000 ALTER TABLE `researches` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `researchesperuser`
--

DROP TABLE IF EXISTS `researchesperuser`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `researchesperuser` (
  `ResearchId` int NOT NULL,
  `cibitId` varchar(45) NOT NULL,
  KEY `FK_USERS_ARITCLES_idx` (`cibitId`),
  KEY `FK_RESARCHES_RESARCHESPERUSER_idx` (`ResearchId`),
  CONSTRAINT `FK_RESARCHES_RESARCHESPERUSER` FOREIGN KEY (`ResearchId`) REFERENCES `researches` (`researchId`),
  CONSTRAINT `FK_USERS_RESARCHESPERUSER` FOREIGN KEY (`cibitId`) REFERENCES `users` (`cibitId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `researchesperuser`
--

LOCK TABLES `researchesperuser` WRITE;
/*!40000 ALTER TABLE `researchesperuser` DISABLE KEYS */;
/*!40000 ALTER TABLE `researchesperuser` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `statustype`
--

DROP TABLE IF EXISTS `statustype`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `statustype` (
  `id` int NOT NULL,
  `description` varchar(45) NOT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `id_UNIQUE` (`id`),
  UNIQUE KEY `description_UNIQUE` (`description`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 MAX_ROWS=3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `statustype`
--

LOCK TABLES `statustype` WRITE;
/*!40000 ALTER TABLE `statustype` DISABLE KEYS */;
INSERT INTO `statustype` VALUES (1,'\'approved\''),(2,'\'declined\''),(0,'\'pending\'');
/*!40000 ALTER TABLE `statustype` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `transactions`
--

DROP TABLE IF EXISTS `transactions`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `transactions` (
  `transatcionId` int NOT NULL AUTO_INCREMENT,
  `cibitSender` varchar(45) NOT NULL,
  `cibitReceiver` varchar(45) NOT NULL,
  `researchId` int NOT NULL,
  `dateTime` datetime NOT NULL,
  `coinAmount` int DEFAULT NULL,
  `status` int NOT NULL,
  `blockNumber` int NOT NULL,
  PRIMARY KEY (`transatcionId`),
  UNIQUE KEY `transatcionId_UNIQUE` (`transatcionId`),
  KEY `cibit Id_idx` (`cibitSender`),
  KEY `FK_USER_TRANSACTIONS_idx` (`cibitReceiver`),
  KEY `FK_RESEARCH_TRANSACTIONS_idx` (`researchId`),
  KEY `FK_TRANSACTIONS_STATUSTYPE` (`status`),
  KEY `FK_BLOCK_TRANSACTION_idx` (`blockNumber`),
  CONSTRAINT `FK_BLOCK_TRANSACTION` FOREIGN KEY (`blockNumber`) REFERENCES `block` (`blockId`),
  CONSTRAINT `FK_RESEARCHES_TRANSACTIONS` FOREIGN KEY (`researchId`) REFERENCES `researches` (`researchId`),
  CONSTRAINT `FK_TRANSACTIONS_STATUSTYPE` FOREIGN KEY (`status`) REFERENCES `statustype` (`id`),
  CONSTRAINT `FK_USERS_TRANSACTIONS_RECEIVER` FOREIGN KEY (`cibitReceiver`) REFERENCES `users` (`cibitId`),
  CONSTRAINT `FK_USERS_TRANSACTIONS_SENDER` FOREIGN KEY (`cibitSender`) REFERENCES `users` (`cibitId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `transactions`
--

LOCK TABLES `transactions` WRITE;
/*!40000 ALTER TABLE `transactions` DISABLE KEYS */;
/*!40000 ALTER TABLE `transactions` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `users`
--

DROP TABLE IF EXISTS `users`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `users` (
  `cibitId` varchar(45) NOT NULL,
  `fName` varchar(45) NOT NULL,
  `lName` varchar(45) NOT NULL,
  `email` varchar(45) NOT NULL,
  `DOB` date DEFAULT NULL,
  `balance` int DEFAULT NULL,
  `status` int NOT NULL,
  `pass` varchar(50) NOT NULL,
  `university` varchar(45) DEFAULT NULL,
  `citationAmount` int DEFAULT NULL,
  PRIMARY KEY (`cibitId`),
  UNIQUE KEY `cibitId_UNIQUE` (`cibitId`),
  KEY `FK_USERS_STATUSTYPE_idx` (`status`),
  CONSTRAINT `FK_USERS_STATUSTYPE` FOREIGN KEY (`status`) REFERENCES `statustype` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `users`
--

LOCK TABLES `users` WRITE;
/*!40000 ALTER TABLE `users` DISABLE KEYS */;
INSERT INTO `users` VALUES ('1','Daniel','Cohn','Daniel.Cohn@mail.huji.ac.il','1980-05-12',0,0,'blasnugw','huji',NULL),('1fCVOhQ','Nadav','Voloch','a@b.com','1984-12-01',0,0,'o/ixgcxOQziXSTmgGVGRlsAz92Jri+8d6iO3VG88Sp1+Au3i','Ben-Gurion University',NULL),('2','Vojin','Oklobdzija','Vojin.Oklobdzija@ ieee.org','1975-01-15',0,0,'afjdsfa','ieee',NULL),('3','Habib','Youssef','Habib.Youssef@fsm.rnu.tn','1970-12-30',0,0,'uodw1dds','Sousse',NULL),('4','Frederick','Berry','Frederick.Berry@purdue.edu ','1986-08-05',0,0,'fhenjf3','purdue',NULL),('Shalom1','Janne','Halme','Janne.Halme@aalto.fi','1982-02-16',0,0,'d82nd7d ','aalto',NULL);
/*!40000 ALTER TABLE `users` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping routines for database 'cibitdb'
--
/*!50003 DROP PROCEDURE IF EXISTS `AddArticle` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `AddArticle`(
IN a_name varchar(200), count int)
BEGIN
insert INTO articles(articleName,citationCount)
values(a_name,count);
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `AddArticlePerUser` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `AddArticlePerUser`(
IN a_id int, c_id varchar(45))
BEGIN
insert INTO ArticlesPerUser(articleId, cibitId)
VALUES(a_id, c_id);
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `AddCoin` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `AddCoin`(
IN coin_id varchar(45),cibit_id varchar(45))
BEGIN
insert INTO Coins(coinId,cibitId)
values(coin_id,cibit_id);
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `AddCoinPerTransactino` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `AddCoinPerTransactino`(
IN c_id varchar(45), t_id int, nc_id varchar(45))
BEGIN
insert INTO CoinsPerTranscation(coinId, transactionsId , newCoinId)
VALUES(c_id, t_id, nc_id);
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `AddResearch` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `AddResearch`(
IN r_name varchar(45))
BEGIN
insert INTO Researches(researchName,status)
VALUES(r_name,0);
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `AddResearchPerUser` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `AddResearchPerUser`(
IN id int, c_id varchar(45))
BEGIN
insert INTO ResearchesPerUser(ResearchId, cibitId)
VALUES(id, c_id);
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `AddTransaction` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `AddTransaction`(
IN sender_id varchar(45), receiver_id varchar(45), research_id varchar(45),date_time datetime, amount int)
BEGIN
declare blockNum int;
set blockNum = (select max(blockId) from block);
insert INTO Transactions(cibitSender, cibitReceiver, researchId, dateTime, coinAmount, status, blockNumber)
values(sender_id, receiver_id, research_id, date_time, amount,0,blockNum);
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `AddUser` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `AddUser`(
IN Id varchar(45), f_name varchar(45), l_name varchar(45), Email varchar(45), dob date, password1 varchar(50), uni varchar(45))
BEGIN
insert INTO Users (cibitId, fName, lName, email, DOB ,balance, status, pass, university)
values(Id, f_name, l_name, Email, dob, 0, 0, password1, uni);
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `CreateArticle` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `CreateArticle`(
IN a_name varchar(200), amount int, Id varchar(45))
BEGIN
IF NOT EXISTS (select *from articles where articleName = a_name) then
	call AddArticle(a_name, amount);
	if last_insert_id() is not null then
		call AddArticlePerUser(last_insert_id(), Id);
        call UpdateUser(Id, amount);
	end if;
elseIF NOT EXISTS (Select articlesperuser.cibitid, a.articleId, a.articleName, a.citationCount
    from articlesperuser Inner join articles a on a.articleId = articlesperuser.articleId
	Where cibitid = id and  a.articleName = a_name) then
	call AddArticlePerUser(a.articleId, Id);
    call UpdateUser(Id, amount);
end if;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `CreateResearch` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `CreateResearch`(
IN c_id varchar(45), r_name varchar(45))
BEGIN
call AddResearch(r_name);
if last_insert_id() is not null then
	call AddResearchPerUser(last_insert_id(),c_id);
end if;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `CreateUser` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `CreateUser`(
IN c_id varchar(45), fname varchar(45), lname varchar(45), dob date ,Email varchar(45),
password1 varchar(50), uni varchar(45), a_name varchar(200), amount int)
BEGIN
call AddUser(c_id, fname, lname, Email, dob,password1, uni);
call AddArticle(a_name, amount);
if last_insert_id() is not null then
	call AddArticlePerUser(last_insert_id(), c_id);
end if;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `getArticle` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `getArticle`(
in aName varchar(200))
BEGIN
select articlename from articles
where articlename =aName;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `getArticles` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `getArticles`(
IN id varchar(45))
BEGIN
Select articlesperuser.cibitid, a.articleId, a.articlename, a.citationCount from articlesperuser
Inner join articles a on a.articleId = articlesperuser.articleId
Where cibitid = id group by a.articleId;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `getUser` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `getUser`(
IN c_id varchar(45))
BEGIN
select cibitId, fName, LName, email, university from users
where cibitId = c_id;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `getUsers` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `getUsers`()
BEGIN
select cibitId, fName, lName, email, university, citationAmount from users
group by cibitId;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `RemoveCoin` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `RemoveCoin`(
IN coin_id varchar(45))
BEGIN

UPDATE Coins
 Set
 cibitId= null
 where
 coin_id = coinId;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `RemoveResearchesPerUser` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `RemoveResearchesPerUser`(
IN c_id varchar(45))
BEGIN
delete FROM ResearchesPerUser WHERE cibitId = c_id;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `RemoveUser` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `RemoveUser`(
IN c_id varchar(45))
BEGIN
DELETE FROM Users where cibitId = c_id;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `RempveArticlesPerUser` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `RempveArticlesPerUser`(
IN C_id varchar(45))
BEGIN
delete FROM ArticlesPerUser WHERE cibitId = c_id;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `UpdateArticle` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `UpdateArticle`(
IN a_id int, amount int)
BEGIN
update articles
set newCitations = amount
where articleId = a_id;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `UpdateCitation` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `UpdateCitation`(
IN c_id varchar(45), a_id int, amount int)
BEGIN
call UpdateArticle(a_id, amount);
call UpdateUser(c_id, amount);
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `UpdateUser` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `UpdateUser`(
IN c_id varchar(45), amount int)
BEGIN
update users
set citationAmount = citationAmount + amount
where cibitId = c_id;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2020-05-02 23:21:22
